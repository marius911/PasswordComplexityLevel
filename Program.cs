using System;

namespace PasswordComplexityLevel
{
    enum PasswordComplexityLevel
    {
        High,
        Medium,
        Low
    }

    struct PasswordComplexity
    {
        public int MinLowercaseChars;
        public int MinUpercaseChars;
        public int MinDigits;
        public int MinSymbols;
        public bool CanContainSimilarChars;
        public bool CanContainAmbiguousChars;
    }

    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();

            Console.WriteLine(GetPasswordComplexityLevel(password));
            Console.Read();
        }

        static PasswordComplexityLevel GetPasswordComplexityLevel(string password)
        {
            PasswordComplexity currentPassword = GetGivenPasswordComplexity(password);

            if (IsRequiredComplexPassword(currentPassword, GetHighPasswordComplexity()))
            {
                return PasswordComplexityLevel.High;
            }
            else if (IsRequiredComplexPassword(currentPassword, GetMediumPasswordComplexity()))
            {
                return PasswordComplexityLevel.Medium;
            }

            return PasswordComplexityLevel.Low;
        }

        private static bool IsRequiredComplexPassword(PasswordComplexity currentPassword, PasswordComplexity requiredComplex)
        {
            if (currentPassword.MinLowercaseChars < requiredComplex.MinLowercaseChars)
            {
                return false;
            }

            if (currentPassword.MinUpercaseChars < requiredComplex.MinUpercaseChars)
            {
                return false;
            }

            if (currentPassword.MinDigits < requiredComplex.MinDigits)
            {
                return false;
            }

            if (currentPassword.MinSymbols < requiredComplex.MinSymbols)
            {
                return false;
            }

            return true;
        }

        private static PasswordComplexity GetGivenPasswordComplexity(string password)
        {
            PasswordComplexity passwordComp;
            passwordComp.MinLowercaseChars = GetLowerCaseCount(password);
            passwordComp.MinUpercaseChars = GetUpperCaseCount(password);
            passwordComp.MinDigits = GetDigitsCount(password);
            passwordComp.MinSymbols = GetSymbolCount(password);
            passwordComp.CanContainSimilarChars = ContainsSimilarChars(password);
            passwordComp.CanContainAmbiguousChars = ContainsAmigousChars(password);

            return passwordComp;
        }

        static PasswordComplexity GetHighPasswordComplexity()
        {
            const int HighComplexityMinLowercaseChars = 5;
            const int HighComplexityMinUppercaseChars = 2;
            const int HighComplexityMinDigits = 2;
            const int HighComplexityMinSymbols = 2;

            return new PasswordComplexity
            {
                MinLowercaseChars = HighComplexityMinLowercaseChars,
                MinUpercaseChars = HighComplexityMinUppercaseChars,
                MinDigits = HighComplexityMinDigits,
                MinSymbols = HighComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }

        static PasswordComplexity GetMediumPasswordComplexity()
        {
            const int MediumComplexityMinLowercaseChars = 3;
            const int MediumComplexityMinUpercaseChars = 1;
            const int MediumComplexityMinDigits = 1;
            const int MediumComplexityMinSymbols = 1;

            return new PasswordComplexity
            {
                MinLowercaseChars = MediumComplexityMinLowercaseChars,
                MinUpercaseChars = MediumComplexityMinUpercaseChars,
                MinDigits = MediumComplexityMinDigits,
                MinSymbols = MediumComplexityMinSymbols,
                CanContainSimilarChars = true,
                CanContainAmbiguousChars = true
            };
        }

        private static bool ContainsAmigousChars(string password)
        {
            foreach (char ambigousChar in "{}[]()/\'\"~,;.<>")
            {
                if (password.Contains(ambigousChar.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsSimilarChars(string password)
        {
            foreach (char similarChar in "l1Io0O")
            {
                if (password.Contains(similarChar.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetSymbolCount(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            int lowerCaseCount = 0;

            foreach (char letter in password)
            {
                if (!char.IsLetterOrDigit(letter))
                {
                    lowerCaseCount++;
                }
            }

            return lowerCaseCount;
        }

        private static int GetDigitsCount(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            int lowerCaseCount = 0;

            foreach (char letter in password)
            {
                if (char.IsDigit(letter))
                {
                    lowerCaseCount++;
                }
            }

            return lowerCaseCount;
        }

        private static int GetUpperCaseCount(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            int lowerCaseCount = 0;

            foreach (char letter in password)
            {
                if (char.IsUpper(letter))
                {
                    lowerCaseCount++;
                }
            }

            return lowerCaseCount;
        }

        private static int GetLowerCaseCount(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            int lowerCaseCount = 0;

            foreach (char letter in password)
            {
                if (char.IsLower(letter))
                {
                    lowerCaseCount++;
                }
            }

            return lowerCaseCount;
        }
    }
}
