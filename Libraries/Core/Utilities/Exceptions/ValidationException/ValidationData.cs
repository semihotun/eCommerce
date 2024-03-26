namespace Core.Utilities.Exceptions.ValidationException
{
    public class ValidationData
    {
        public ValidationData(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    };
}
