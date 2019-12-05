using System;
using System.Collections.Generic;
using System.Text;
using Extensions;

namespace Calendar.December04
{
    public class PasswordGenerator
    {
        private string _lowerRange;
        private string _upperRange;
        private List<string> _pwList;
        public PasswordGenerator(string Range)
        {
            _lowerRange = Range.Split('-')[0];
            _upperRange = Range.Split('-')[1];
            _pwList = new List<string>();
        }

        private bool VerifyPassword(string Password)
        {
            for (int i = 1; i < Password.Length; i++)
            {
                if (Password[i] == Password[i-1])
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> GeneratePasswordList()
        {
            string currentPassword = _lowerRange;
            while (currentPassword.CompareTo(_upperRange) < 0)
            {
                currentPassword = currentPassword.SetConsecutive();
                if (currentPassword.CompareTo(_upperRange) > 0)
                {
                    break;
                }
                if (VerifyPassword(currentPassword))
                {
                    _pwList.Add(currentPassword);
                    Console.WriteLine(currentPassword);
                }
                currentPassword = currentPassword.IncrementPassword();
            }

            return _pwList;
        }

    }
}
