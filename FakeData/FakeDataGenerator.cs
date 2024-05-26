namespace FakeDataGeneratorMinimalApi.FakeData
{
    public class FakeDataGenerator
    {
        public static string GenerateCpf()
        {
            var random = new Random();
            int[] cpfArray = new int[9];

            for (int i = 0; i < 9; i++)
            {
                cpfArray[i] = random.Next(0, 9);
            }

            int firstVerifier = CalculateCpfVerifier(cpfArray);
            int secondVerifier = CalculateCpfVerifier(cpfArray.Append(firstVerifier).ToArray());

            return string.Join("", cpfArray) + firstVerifier + secondVerifier;
        }

        private static int CalculateCpfVerifier(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i] * (numbers.Length + 1 - i);
            }
            int result = sum % 11;
            return result < 2 ? 0 : 11 - result;
        }

        public static string GenerateCnpj()
        {
            var random = new Random();
            int[] cnpjArray = new int[12];

            for (int i = 0; i < 12; i++)
            {
                cnpjArray[i] = random.Next(0, 9);
            }

            int firstVerifier = CalculateCnpjVerifier(cnpjArray);
            int secondVerifier = CalculateCnpjVerifier(cnpjArray.Append(firstVerifier).ToArray());

            return string.Join("", cnpjArray) + firstVerifier + secondVerifier;
        }

        private static int CalculateCnpjVerifier(int[] numbers)
        {
            int[] multipliers = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            if (numbers.Length == 13)
            {
                multipliers = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            }

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i] * multipliers[i];
            }
            int result = sum % 11;
            return result < 2 ? 0 : 11 - result;
        }
    }
}
