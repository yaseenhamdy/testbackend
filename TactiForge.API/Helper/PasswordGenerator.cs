namespace TactiForge.API.Helper
{
    public static class PasswordGenerator
    {
        public static string GenerateRandomPassword(int length = 10)
        {
            // Define character sets
            const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*";

            // Combine all character sets
            var allChars = capitalLetters + smallLetters + digits + specialChars;

            // Random number generator
            var random = new Random();

            // Ensure at least one character from each set
            var passwordChars = new List<char>
        {
            capitalLetters[random.Next(capitalLetters.Length)], // At least one capital letter
            smallLetters[random.Next(smallLetters.Length)],     // At least one small letter
            digits[random.Next(digits.Length)],                // At least one digit
            specialChars[random.Next(specialChars.Length)]     // At least one special character
        };

            // Fill the rest of the password with random characters from allChars
            for (int i = passwordChars.Count; i < length; i++)
            {
                passwordChars.Add(allChars[random.Next(allChars.Length)]);
            }

            // Shuffle the characters to ensure randomness
            passwordChars = passwordChars.OrderBy(c => random.Next()).ToList();

            // Convert the list of characters to a string
            return new string(passwordChars.ToArray());
        }
    }
}

