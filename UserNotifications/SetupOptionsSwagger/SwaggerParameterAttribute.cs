namespace UserNotifications.SetupOptionsSwagger
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]

    internal class SwaggerParameterAttribute: Attribute
    {
        public SwaggerParameterAttribute(string name, string value)
        {
            Name = value;
            Value = value;
        }
        public SwaggerParameterAttribute(string value)
        {
            Name = value;
            Value = value;
        }
        public string? Name { get; set; }
        public string? Value { get; set; }
    }

}
