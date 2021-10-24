using System;

namespace GenericValidation
{
    static class InputValidation
    {
        static public T GenericReadValidation<T>(string message) where T : struct
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine(message);

                string input = Console.ReadLine();
                isValid = input.TryParse(out T validatedOutput);

                if (isValid)
                {
                    return validatedOutput;
                }
                else
                {
                    ShowErrorMessage();
                }
            }

            throw new ApplicationException("Method shouldn't reach this point. Something terribly wrong happended.");
        }

        public static bool TryParse<T>(this string input, out T output)
        {
            var type = typeof(T);
            var temp = default(T);
            var method = type.GetMethod(
                "TryParse",
                new[]
                    {
                        typeof (string),
                        Type.GetType(string.Format("{0}&", type.FullName))
                    });

            output = temp;
            return (bool)method.Invoke(null, new object[] { input, temp });
        }

        private static void ShowErrorMessage()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Entrada inválida. Tente novamente\n");
            Console.ResetColor();
        }
    }
}
