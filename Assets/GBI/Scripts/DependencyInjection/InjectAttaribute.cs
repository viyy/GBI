using System;

namespace Geekbrains
{
    /// <summary>
    /// Класс, описывающий атрибут Inject для DIContainerа
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
        public InjectAttribute() {}
    }
}