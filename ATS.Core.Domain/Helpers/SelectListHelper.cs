﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ATS.Core.Domain.Helpers
{
    public static class SelectListHelper
    {
        /// <summary>
        /// The SelectListItem to use by default as the placeholder for any select lists generated by these extension methods.
        /// </summary>
        public static readonly SelectListItem DefaultEmptySelectListItem = new SelectListItem() { Text = "Selecione uma opção", Value = "" };

        #region String Keys

        /// <summary>
        /// Returns a collection of SelectListItem for each of the items in the collection passed in.
        /// </summary>
        /// <example>
        /// people.ToSelectList(x => x.PersonId, x => x.Name);
        /// </example>
        /// <param name="key">The property to use as the value attribute of each list item.</param>
        /// <param name="text">The property to use as the text attribute of each list item.</param>
        public static IList<SelectListItem> ToSelectList<TType, TKey>(this IEnumerable<TType> enumerable, Func<TType, TKey> key, Func<TType, string> text) where TType : class
        {
            return ToSelectList(enumerable, key, text, null, true);
        }

        /// <summary>
        /// Returns a collection of SelectListItem for each of the items in the collection passed in, with a specific list item selected and optionally an empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// people.ToSelectList(x => x.PersonId, x => x.Name, "2345");
        /// // or
        /// people.ToSelectList(x => x.PersonId, x => x.Name, "2345", false); if you don't want the empty list item
        /// </code>
        /// </example>
        /// <param name="key">The property to use as the value attribute of each list item.</param>
        /// <param name="text">The property to use as the text attribute of each list item.</param>
        /// <param name="currentKey">The String value of the list item that should be selected by default.</param>
        /// <param name="includeEmptyListItem">Whether or not a default list item should be the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TType, TKey>(this IEnumerable<TType> enumerable, Func<TType, TKey> key, Func<TType, string> text, TKey currentKey, bool includeEmptyListItem = true) where TType : class
        {
            return ToSelectList(enumerable, key, text, currentKey, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        /// <summary>
        /// Returns a collection of SelectListItem for each of the items in the collection passed in, with a specific list item selected and a custom empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// people.ToSelectList(x => x.PersonId, x => x.Name, "2345", new SelectListItem() {Text = "-- Pick One --", Value = ""});
        /// </code>
        /// </example>
        /// <param name="key">The property to use as the value attribute of each list item.</param>
        /// <param name="text">The property to use as the text attribute of each list item.</param>
        /// <param name="currentKey">The String value of the list item that should be selected by default.</param>
        /// <param name="emptyListItem">The list item to use as the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TType, TKey>(this IEnumerable<TType> enumerable, Func<TType, TKey> key, Func<TType, string> text, TKey currentKey, SelectListItem emptyListItem) where TType : class
        {
            return ToSelectList(enumerable, key, text, new TKey[] { currentKey }, emptyListItem);
        }

        public static IList<SelectListItem> ToSelectList<TType, TKey>(this IEnumerable<TType> enumerable, Func<TType, TKey> key, Func<TType, string> text, IEnumerable<TKey> currentKeys, bool includeEmptyListItem = true) where TType : class
        {
            return ToSelectList(enumerable, key, text, currentKeys, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        public static IList<SelectListItem> ToSelectList<TType, TKey>(this IEnumerable<TType> enumerable, Func<TType, TKey> key, Func<TType, string> text, IEnumerable<TKey> currentKeys, SelectListItem emptyListItem) where TType : class
        {
            var selectList = new List<SelectListItem>();
            if (enumerable != null)
                selectList = enumerable.Select(x => new SelectListItem() { Value = key.Invoke(x).ToString(), Text = text.Invoke(x), Selected = (currentKeys != null && currentKeys.Contains(key.Invoke(x))) }).ToList();
            if (emptyListItem != null)
                selectList.Insert(0, emptyListItem);
            return selectList;
        }

        #endregion String Keys

        #region Enumerable Enums

        // The following three methods are only present in case you wish to control how the list if Enum's is built, useful if you need to omit some due for security reasons.
        // Check out http://www.kodefuguru.com/post/2011/09/21/Empowering-Enums.aspx for a good example of how to do this yourself
        public static IList<SelectListItem> ToSelectList<TEnum>(this IEnumerable<TEnum> enumerable, TEnum? currentKey, bool includeEmptyListItem = true) where TEnum : struct
        {
            return ToSelectList(enumerable, currentKey, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        public static IList<SelectListItem> ToSelectList<TEnum>(this IEnumerable<TEnum> enumerable, int currentKey, bool includeEmptyListItem = true) where TEnum : struct
        {
            TEnum enumCurrentKey = (TEnum)Enum.ToObject(typeof(TEnum), currentKey);
            return ToSelectList(enumerable, enumCurrentKey, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        /// <summary>
        /// Returns a collection of SelectListItem from a provided collection of Enum. Typically you would do this when you are starting with nothing and just have the Enum you want to use.
        /// </summary>
        /// <example>
        /// <code>
        /// IEnumerable&lt;EnumName&gt; myEnums = Intellitive.ExtensionMethods.AsEnumerable&lt;EnumName&gt;();
        /// myEnums.ToSelectList(currentKey, new SelectListItem() {Text = "-- Pick One --", Value = ""});
        /// </code>
        /// </example>
        public static IList<SelectListItem> ToSelectList<TEnum>(this IEnumerable<TEnum> enumerable, TEnum? currentKey, SelectListItem emptyListItem) where TEnum : struct
        {
            var selectList = new List<SelectListItem>();
            if (enumerable != null)
                selectList = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(x => new SelectListItem() { Value = x.ToString(), Text = x.ToString(), Selected = currentKey != null && (int)(object)x == (int)(object)currentKey }).ToList();
            if (emptyListItem != null)
                selectList.Insert(0, emptyListItem);
            return selectList;
        }

        #endregion Enumerable Enums

        /// <summary>
        /// Returns a collection of SelectListItem for each possible value of an Enum, with a specific list item selected and optionally an empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// ExtensionMethods.ToSelectList<Colors>(2);
        /// // or
        /// ExtensionMethods.ToSelectList<Colors>(2, false); if you don't want the empty list item
        /// </code>
        /// </example>
        /// <param name="currentKey">The Guid value of the list item that should be selected by default.</param>
        /// <param name="includeEmptyListItem">Whether or not a default list item should be the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TEnum>(int currentKey, bool includeEmptyListItem = true) where TEnum : struct
        {
            TEnum enumCurrentKey = (TEnum)Enum.ToObject(typeof(TEnum), currentKey);
            return ToSelectList<TEnum>(enumCurrentKey, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        /// <summary>
        /// Returns a collection of SelectListItem for each possible value of an Enum, and optionally an empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// ExtensionMethods.ToSelectList<Colors>();
        /// // or
        /// ExtensionMethods.ToSelectList<Colors>(false); if you don't want the empty list item
        /// </code>
        /// </example>
        /// <param name="includeEmptyListItem">Whether or not a default list item should be the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TEnum>(bool includeEmptyListItem = true) where TEnum : struct
        {
            return ToEnumSelectList<TEnum>(null, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        /// <summary>
        /// Returns a collection of SelectListItem for each possible value of an Enum, with a specific list item selected and optionally an empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// // Useful when your enum is a nullable viewmodel
        /// Colors? viewModel = null;
        /// ExtensionMethods.ToSelectList(viewModel)
        /// </code>
        /// </example>
        /// <param name="currentKey">The Guid value of the list item that should be selected by default.</param>
        /// <param name="includeEmptyListItem">Whether or not a default list item should be the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TEnum>(TEnum? currentKey, bool includeEmptyListItem = true) where TEnum : struct
        {
            return ToEnumSelectList(currentKey, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        /// <summary>
        /// Returns a collection of SelectListItem for each possible value of an Enum, with a specific list item selected and optionally an empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// Colors.Green.ToSelectList();
        /// // or
        /// Colors.Green.ToSelectList(false); if you don't want the empty list item
        /// // or
        /// var color = Colors.Green;
        /// color.ToSelectList();
        /// </code>
        /// </example>
        /// <param name="includeEmptyListItem">Whether or not a default list item should be the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TEnum>(this TEnum currentKey, bool includeEmptyListItem = true) where TEnum : struct
        {
            return ToSelectList(currentKey, includeEmptyListItem ? DefaultEmptySelectListItem : null);
        }

        /// <summary>
        /// Returns a collection of SelectListItem for each possible value of an Enum, with a specific list item selected and a custom empty list item.
        /// </summary>
        /// <example>
        /// <code>
        /// Colors.Green.ToSelectList(new SelectListItem() {Text = "~~ Pick One!!! ~~", Value = string.Empty}).Dump();
        /// </code>
        /// </example>
        /// <param name="emptyListItem">The list item to use as the first list item before those from the collection.</param>
        public static IList<SelectListItem> ToSelectList<TEnum>(this TEnum currentKey, SelectListItem emptyListItem) where TEnum : struct
        {
            return ToEnumSelectList<TEnum>(currentKey, emptyListItem);
        }

        private static IList<SelectListItem> ToEnumSelectList<TEnum>(TEnum? currentKey, SelectListItem emptyListItem) where TEnum : struct
        {
            IList<SelectListItem> selectList;
            if (typeof(TEnum).GetCustomAttributes(typeof(FlagsAttribute), false).Any())
                selectList = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(x => new SelectListItem() { Value = x.ToString(), Text = x.ToString(), Selected = currentKey != null && ((int)(object)x & (int)(object)currentKey) == (int)(object)x }).ToList();
            else
                selectList = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(x => new SelectListItem() { Value = x.ToString(), Text = x.ToString(), Selected = currentKey != null && (int)(object)x == (int)(object)currentKey }).ToList();

            if (emptyListItem != null)
                selectList.Insert(0, emptyListItem);
            return selectList;
        }
    }
}
