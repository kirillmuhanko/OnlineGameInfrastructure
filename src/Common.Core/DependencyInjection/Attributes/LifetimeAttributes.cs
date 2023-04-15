namespace Common.Core.DependencyInjection.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public abstract class LifetimeAttributeBase : Attribute
{
}

public class TransientLifetimeAttribute : LifetimeAttributeBase
{
}

public class ScopedLifetimeAttribute : LifetimeAttributeBase
{
}

public class SingletonLifetimeAttribute : LifetimeAttributeBase
{
}