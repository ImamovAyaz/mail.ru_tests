using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.ru_Tests
{
    public class EmailData
    {
        private string whom;
        private string theme;
        private string bodyEmail;

        public EmailData(string whom)
        {
            this.whom = whom;
        }
        public EmailData()
        {

        }

        public string Whom
        {
            get
            {
                return whom;
            }
            set
            {
                whom = value;
            }
        }

        public string Theme
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
            }
        }
        public string BodyEmail
        {
            get
            {
                return bodyEmail;
            }
            set
            {
                bodyEmail = value;
            }
        }
    }
}
