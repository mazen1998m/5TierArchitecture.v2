﻿namespace App.core.InjectionHelper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InjectionAttribute : Attribute
    {
        public Type Interface { get; }
        public Type Implementation { get; }
        public int Order { get; set; }

        public InjectionAttribute(Type interfaceType, Type implementationType, int order = 999)
        {
            Order = order;
            Interface = interfaceType;
            Implementation = implementationType;
        }
    }
}

