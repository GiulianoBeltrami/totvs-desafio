using totvs_desafio.Database;

namespace totvs_desafio.Models
{
    public class Validations
    {
        private User _user;

        public Validations(User user)
        {
            _user = user;
        }

        public bool isRegistrationFieldsFilled()
        {
            return isEmailFilled() && isNameFilled() && isPasswordFilled() && isProfilesFilled();
        }

        public bool isLoginFieldsFilled()
        {
            return isEmailFilled() && isPasswordFilled();
        }

        public bool isExistingEmail()
        {
            var user = DapperQuery.getUserByEmail(_user.email);

            if (user == null)
            {
                return false;
            }
            return true;
        }

        public bool isLastAccessedFilled()
        {
            return _user.LastAccessed != null;

        }

        private bool isEmailFilled()
        {
            return _user.email != null;
        }

        private bool isNameFilled()
        {
            return _user.name != null;
        }

        private bool isPasswordFilled()
        {
            return _user.password != null;
        }

        private bool isProfilesFilled()
        {
            return _user.profile != null;
        }
    }
}
