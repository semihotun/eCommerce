using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Identity
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { 
            return new IdentityError {
                Code = nameof(DefaultError), Description = $"Bilinmeyen bir hata oluştu" 
            }; 
        }
        public override IdentityError ConcurrencyFailure() { 
            return new IdentityError {
                Code = nameof(ConcurrencyFailure), Description = "Eşzamanlı işlem" 
            }; 
        }
        public override IdentityError PasswordMismatch() { 
            return new IdentityError { 
                Code = nameof(PasswordMismatch), Description = "Parola yanlış." 
            }; 
        }
        public override IdentityError InvalidToken() { 
            return new IdentityError {
            Code = nameof(InvalidToken), Description = "Geçersiz jeton" 
            }; 
        }
        public override IdentityError LoginAlreadyAssociated() { 
            return new IdentityError {
                Code = nameof(LoginAlreadyAssociated), Description = "Bu kullanıcı adı zaten giriş yaptı" 
            };
        }
        public override IdentityError InvalidUserName(string userName) { 
            return new IdentityError {
                Code = nameof(InvalidUserName), Description = $"Kullanıcı adı a-z A-Z harflerini içerebilir" 
            };
        }
        public override IdentityError InvalidEmail(string email) {
            return new IdentityError { Code = nameof(InvalidEmail), Description = $"Email geçersiz" 
            }; 
        }
        public override IdentityError DuplicateUserName(string userName) { 
            return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Kullanıcı Adı Zaten alınmış" 
            };
        }
        public override IdentityError DuplicateEmail(string email) { 
            return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Email zaten alınmış" 
            }; 
        }
        public override IdentityError InvalidRoleName(string role) { 
            return new IdentityError { Code = nameof(InvalidRoleName), Description = $"Geçersiz Rol tanımı" 
            }; 
        }
        public override IdentityError DuplicateRoleName(string role) { 
            return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Role zaten alınmış" 
            };
        }
        public override IdentityError UserAlreadyHasPassword() {
            return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "Kullanıcının zaten bir parola seti var"
            }; 
        }
        public override IdentityError UserLockoutNotEnabled() { 
            return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Bu kullanıcı için kilitleme etkin değil"
            };
        }
        public override IdentityError UserAlreadyInRole(string role) { 
            return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"Kullanıcı zaten rolde" 
            }; 
        }
        public override IdentityError PasswordTooShort(int length) { 
            return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Şifre en az {length} karakter olmalı" 
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric() { 
            return new IdentityError { 
                Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Parolalar en az bir alfasayısal olmayan karaktere sahip olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresDigit() {
            return new IdentityError { 
                Code = nameof(PasswordRequiresDigit), Description = "Şifreler en az bir rakamdan oluşmalıdır ('0'-'9')"
            }; 
        }
        public override IdentityError PasswordRequiresLower() { 
            return new IdentityError {
                Code = nameof(PasswordRequiresLower), Description = "Parolalarda en az bir küçük harf ('a'-'z') olmalıdır"
            }; 
        }
        public override IdentityError PasswordRequiresUpper() { 
            return new IdentityError { 
                Code = nameof(PasswordRequiresUpper), Description = "Parolalarda en az bir büyük harf ('A'-'Z') olmalıdır"
            };
        }


        //public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = "DuplicateUserName", Description = $"\"{ userName }\" kullanıcı adı kullanılmaktadır." };
        //public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = "InvalidUserName", Description = "Geçersiz kullanıcı adı." };
        //public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = "DuplicateEmail", Description = $"\"{ email }\" başka bir kullanıcı tarafından kullanılmaktadır." };
        //public override IdentityError InvalidEmail(string email) => new IdentityError { Code = "InvalidEmail", Description = "Geçersiz email." };
    }
}
