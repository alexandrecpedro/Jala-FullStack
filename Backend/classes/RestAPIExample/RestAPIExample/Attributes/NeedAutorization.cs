namespace RestAPIExample.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class NeedAutorizationAttribute : Attribute
{
}