using FixedAsset.Models;
using FixedAsset.Models.User;
using FixedAsset.Repository.Setup;
using FixedAsset.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace FixedAsset.Controllers
{
    public class UserController : Controller
    {
        private IUserRepo _entity;
        private IDepartment _IDepartment;
        private IBranch _IBranch;
        private IRole _IRole;
 
 

        public UserController()
        {
            _entity = new UserRepo(new Models.FixedAssetEntities());
            _IDepartment = new Department(new Models.FixedAssetEntities());
            _IBranch = new Branch(new Models.FixedAssetEntities());
            _IRole = new Role(new Models.FixedAssetEntities());
  

        }

        public UserController(IUserRepo entity, IDepartment IDepartment, IBranch IBranch, IRole IRole)
        {
            _entity = entity;
            _IDepartment = IDepartment;
            _IBranch = IBranch;
            _IRole = IRole;
        }
        //public ActionResult CreateUser()
        //{
        //    return View();
        //}

        //public ActionResult Login()
        //{
        //    return View();
        //}
  


        public static int? userRoleId = 0;
        [Authorize]
        public ActionResult Userlist()
        {
            var model = _entity.Get_Users();
            return View(model);
          

        }
        [Authorize]
        // Registration action 
        [HttpGet]
        public ActionResult CreateUser()
        {
            var dept = _IDepartment.GetDepartment();
            ViewBag.dept = dept;
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            var Role = _IRole.GetRole();
            ViewBag.Role = Role;
            return View();
        }
        //registration Post Action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Exclude = "IsEmailVerified, ActivationCode")] UserModel user)
        {
            var dept = _IDepartment.GetDepartment();
            ViewBag.dept = dept;
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            var Role = _IRole.GetRole();
            ViewBag.Role = Role;
            bool Status = false;
            string Message = "";
            user.authid = "";
            //user.Authoriser = "";
            //user.Authoriser = "";
            //Model Validation 
            if (ModelState.IsValid)
            {
                #region//Email is already exist
                var isExist = IsEmailExist(user.email);
                var useExist = IsUserExist(user.Userid);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                if (useExist)
                {
                    ModelState.AddModelError("useExist", "User already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing
                user.userpassword = Crypto.Hash(user.userpassword);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);//
                #endregion
                user.IsEmailVerified = false;
                #region save to database

                //db.tbl_userprofile.Add(user);
                //db.SaveChanges();


                //SqlParameter Retval = new SqlParameter("@retval", SqlDbType.Int);
                //Retval.Direction = System.Data.ParameterDirection.Output;

                //SqlParameter RetMsg = new SqlParameter("@retmsg", SqlDbType.VarChar, 200);
                //RetMsg.Direction = System.Data.ParameterDirection.Output;

                //var ftr = db.Database.ExecuteSqlCommand("Proc_CreateUserProfile @Userid, @fullname,@email,@phone,@password,@confirmPassword," +
                //    "@retval OUT, @retmsg OUT",
                //    new SqlParameter("@Userid", user.Userid),
                //    new SqlParameter("@fullname", user.fullname),
                //    new SqlParameter("@email", user.email),
                //    new SqlParameter("@phone", user.phoneno),
                //    new SqlParameter("@password", user.userpassword),
                //    new SqlParameter("@confirmPassword", user.ConfirmPassword), Retval, RetMsg);

                //int xRetval = Convert.ToInt32(Retval.Value.ToString());

                //string xRetMsg = RetMsg.Value.ToString();

                var result = _entity.InsUser(user);

                    if (result.retVal == 0)
                    {
                        Message = " Registration successfully done. Account activation link " +
                   "has been sent to your email Id ";/*+ user.EmailId;*/
                        // send email to user
                        //SendVerificationEmailLink(user.EmailId, user.ActivationCode.ToString());
                        //Message = "Registration successfully done. Account activation link " +
                        //    "has been sent to your email Id " + user.EmailId;
                        Status = true;
                    }
                    else
                    {
                        Message = "oops!! something went wrong";
                        Status = false;
                    }


                
                #endregion
            }
            else
            {

                Message = "Invalid request";
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View(user);
        }
        // Verify Account


        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (FixedAssetEntities dc = new FixedAssetEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;//this line I have added here to avoid confirm password does not match issues
                                                               //on save
                var v = dc.tbl_userprofile.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;


                }
                else
                {

                    ViewBag.Message = "Invalid request";
                }


            }
            ViewBag.Status = Status;
            return View();


        }
        //Verify Email LINK

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(UserLogin login, string returnUrl)
        {
            string message = "";
            bool Status = false;
            try
            {
                using (FixedAssetEntities db = new FixedAssetEntities())
                {
                    var v = db.tbl_userprofile.Where(a => a.Userid == login.UserId).FirstOrDefault();
                    //var v1 = db.tbl_userprofile.Where(a => a.userid == login.UserId).FirstOrDefault();
                    if (v != null)
                    {
                        if (string.Compare(Crypto.Hash(login.Password), v.userpassword) == 0)
                        {
                            DateTime now = DateTime.Now;
                            HttpCookie mycookie = new HttpCookie("roleid");
                            mycookie.Value = v.Role_id.ToString();
                            mycookie.Expires = now.AddYears(50);

                            Response.Cookies.Add(mycookie);
                            int timeout = login.RememberMe ? 525600 : 20;//525600 mins ! year
                            var ticket = new FormsAuthenticationTicket(login.UserId, login.RememberMe, timeout);
                            string encrypted = FormsAuthentication.Encrypt(ticket);
                            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                            cookie.Expires = DateTime.Now.AddMinutes(timeout);
                            cookie.HttpOnly = true;
                            Response.Cookies.Add(cookie);
                            if (Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }

                        }
                        else
                        {
                            Status = true;
                            message = "Invalid credential provided";
                        }
                    }
                    else
                    {
                        Status = true;
                        message = "Incorrect Username and Password Please enter correct Username and password";
                    }
                }
            }
            catch (Exception e)
            {
                Status = true;
                message = "Oops!! something went wrong. " + e.Message;
            }

            ViewBag.status = Status;
            ViewBag.Message = message;
            return View();

        }
        // Logout
        //[Authorize]
        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");

        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (FixedAssetEntities db = new FixedAssetEntities())
            {
                var v = db.tbl_userprofile.Where(a => a.email == emailID).FirstOrDefault();
                return v != null;
            }

        }
        public bool IsUserExist(string UserId)
        {
            using (FixedAssetEntities db = new FixedAssetEntities())
            {
                var user = db.tbl_userprofile.Where(a => a.Userid == UserId).FirstOrDefault();
                return user != null;
            }

        }
        [NonAction]
        public void SendVerificationEmailLink(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            try
            {
                var verifyUrl = "/User/" + emailFor + "/" + activationCode;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                var fromMail = new MailAddress("admin@ekitimeda.com", "MEDA");
                //var fromMail = new MailAddress("abbasjohn17@gmail.com", "MEDA");
                var ToMail = new MailAddress(emailID);
                var fromMailPassword = "ekiti@2020"; //Replace with actual password
                                                     //var fromMailPassword = "Tabernacle@@@@@,"; //Replace with actual password
                                                     //var fromMailPassword = "Pass123...000"; //Replace with actual password
                string subject = "";
                string body = "";
                if (emailFor == "VerifyAccount")
                {
                    subject = "Your account is successfully created";
                    body = "</br></br> we are excited to tell you that you have been profiled on this system." +
                        " please click on the link below to verify your account" +
                        "</br></br><a href='" + link + "'>" + link + "</a>";
                }
                else if (emailFor == "ResetPassword")
                {
                    subject = "Reset Password";
                    body = "<br/><br/>We got request for reset your Account password. Please, click on the below link to reset your password" +
                        "<br/><br/> <a href=" + link + "> Reset password link</a>";
                }


                var smtp = new SmtpClient
                {
                    //Host = "sbsserver.bosakmfb.com",
                    Host = "mail.ekitimeda.com",
                    ////Host = "smtp.gmail.com",
                    //Port = 465,
                    Port = 587,
                    //Port = 25,
                    EnableSsl = false,
                    //EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromMail.Address, fromMailPassword)

                };
                using (var message = new MailMessage(fromMail, ToMail)
                {

                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true

                })
                    //smtp.EnableSsl = true;
                    //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }



                    smtp.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {

            return View();
        }

        //[HttpPost,ActionName("ForgotPassword1")]
        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            //verify Email
            //if valid
            //generate password reset link
            // send to Email Id
            string message = "";
            bool status = false;

            using (FixedAssetEntities db = new FixedAssetEntities())
            {
                var account = db.tbl_userprofile.Where(a => a.email == EmailID).FirstOrDefault();
                if (account != null)
                {
                    //send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationEmailLink(account.email, resetCode, "ResetPassword");
                    account.PasswordResetCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    status = true;
                    message = "Reset password link has been sent to your email";
                }
                else
                {
                    status = true;
                    message = "Account not found!";
                }
            }
            ViewBag.Status = status;
            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        public ActionResult ResetPassword(string id)
        {
            // verify the reset password link
            // find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }
            using (FixedAssetEntities dc = new FixedAssetEntities())
            {

                var user = dc.tbl_userprofile.Where(a => a.PasswordResetCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);

                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        //[HttpPost, ActionName("ResetPassword1")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            bool status = false;
            if (ModelState.IsValid)
            {

                using (FixedAssetEntities db = new FixedAssetEntities())
                {
                    var user = db.tbl_userprofile.Where(a => a.PasswordResetCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.userpassword = Crypto.Hash(model.NewPassword);
                        user.PasswordResetCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        status = true;
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                status = true;
                message = "Reset Code is Invalid";
            }
            ViewBag.Status = status;
            ViewBag.Message = message;
            return View(model);
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            FixedAssetEntities db = new FixedAssetEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_userprofile tbl_recon_bank = db.tbl_userprofile.Find(id);
            if (tbl_recon_bank == null)
            {
                return HttpNotFound();
            }
            return View(tbl_recon_bank);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(string UserId)
        {
            var dept = _IDepartment.GetDepartment();
            ViewBag.dept = dept;
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            var Role = _IRole.GetRole();
            ViewBag.Role = Role;
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _entity.GetUserByID(UserId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel model)
        {
            var dept = _IDepartment.GetDepartment();
            ViewBag.dept = dept;
            var Branch = _IBranch.GetBranch();
            ViewBag.Branch = Branch;
            var Role = _IRole.GetRole();
            ViewBag.Role = Role;
            bool Status = false;
            string Message = "";
            try
            {
                model.authid = "";
             
                if (ModelState.IsValid)
                {
                    var data = _entity.Up_User(model);
                    if (data.retVal == 0)
                    {
                        Status = true;
                        Message = data.retmsg;
                    }
                    else
                    {
                        Status = false;
                        Message = data.retmsg;
                    }
                }
           
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!" + e.Message);
                Message = "Invalid request";
                Status = true;
            }
            ViewBag.Message = Message;
            ViewBag.Status = Status;
            return View(model);
        }

        public ActionResult Delete(string UserId)
        {
            var model = new UserModel();
            model.Userid = UserId;
            model.authid = "";

            var result = _entity.DeactivateUser(model);
            if (result.retVal == 0)
            {
                ViewBag.Message = String.Format("Error!!!{0}", result.retmsg);
                return RedirectToAction("UserList", "Setup");
            }
            else
            {
                ViewBag.Message = String.Format("Error!!!{0}", result.retmsg);
            }
            return View(model);
        }

        [Authorize]
   
        protected override void Dispose(bool disposing)
        {
            FixedAssetEntities db = new FixedAssetEntities();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}