namespace GenericValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = InputValidation.GenericReadValidation<int>("Input the age");
            float salary = InputValidation.GenericReadValidation<float>("Input the salary");
        }
    }
}