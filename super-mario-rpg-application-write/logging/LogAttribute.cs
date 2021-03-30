using System;

namespace SuperMarioRpg.Application.Write
{
    /// <summary>
    ///     <para>Checked for during <see cref="AutofacModule" /> registration.</para>
    ///     <para>Indicates a class is capable of being logged.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class LogAttribute : Attribute
    {
    }
}
