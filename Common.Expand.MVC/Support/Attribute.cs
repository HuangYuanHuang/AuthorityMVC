﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExpandMVC.Support
{
    /// <exclude/>
    [AttributeUsage(AttributeTargets.Field)]
    internal class NameFieldAttribute : Attribute
    {
        /// <exclude/>
        public string Name { get; set; }
    }

    /// <exclude/>
    [AttributeUsage(AttributeTargets.Field)]
    internal class ValueFieldAttribute : NameFieldAttribute
    {
        /// <exclude/>
        public string Value { get; set; }
    }

    /// <exclude/>
    [AttributeUsage(AttributeTargets.Property)]
    public class TreeTextAttribute : Attribute
    {
        /// <exclude/>
        public string Value { get; set; }
    }

    /// <exclude/>
    [AttributeUsage(AttributeTargets.Property)]
    public class ClassNameAttribute : Attribute
    {
        /// <exclude/>
        public string Value { get; set; }
    }

    /// <exclude/>
    [AttributeUsage(AttributeTargets.Property)]
    public class RadioStateAttribute : Attribute
    {
        /// <exclude/>
        public string Value { get; set; }
    }
    /// <exclude/>
    internal static class FieldAttributeExtensions
    {
        /// <exclude/>
        public static string FieldName(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttribute<NameFieldAttribute>();
            return attr != null ? attr.Name : null;
        }

        /// <exclude/>
        public static string FieldValue(this Enum value)
        {
            var attr = value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueFieldAttribute>();
            return attr != null ? attr.Value : null;
        }
    }
}
