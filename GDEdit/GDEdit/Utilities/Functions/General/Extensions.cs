﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GDEdit.Utilities.Functions.General
{
    public static class Extensions
    {
        public static bool Contains<T>(this T[] a, T item)
        {
            for (int i = 0; i < a.Length; i++)
            {
                try
                {
                    var x = Expression.Constant(a[i], typeof(T));
                    var y = Expression.Constant(item, typeof(T));
                    Expression shit = Expression.Convert(Expression.IsTrue(Expression.Equal(x, y)), typeof(bool));
                    if (Expression.Lambda<Func<bool>>(shit).Compile()())
                        return true;
                }
                catch
                {
                    if (a[i].Equals(item))
                        return true;
                }
            }
            return false;
        }
        public static bool Contains(this int[] a, int item)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == item)
                    return true;
            return false;
        }
        public static bool Contains(this Enum e, int value)
        {
            return ((int[])(Enum.GetValues(e.GetType()))).Contains(value);
        }

        public static bool MatchIndices(this List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
                if (l[i] != i)
                    return false;
            return true;
        }
        public static bool MatchIndicesFromEnd(this List<int> l, int length)
        {
            for (int i = l.Count - 1; i >= 0; i--)
                if (l[i] != length - l.Count + i)
                    return false;
            return true;
        }
        public static int FindIndexInList(this List<int> l, int match)
        {
            for (int i = 0; i < l.Count; i++)
                if (l[i] == match)
                    return i;
            return -1;
        }
        public static List<int> RemoveDuplicates(this List<int> l)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < l.Count; i++)
                if (!newList.Contains(l[i]))
                    newList.Add(l[i]);
            return newList;
        }
        public static List<int> RemoveNegatives(this List<int> l)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < l.Count; i++)
                if (l[i] >= 0)
                    newList.Add(l[i]);
            return newList;
        }
        public static int Max(this List<int> l)
        {
            int max = int.MinValue;
            for (int i = 0; i < l.Count; i++)
                if (l[i] > max)
                    max = l[i];
            return max;
        }
        public static int Min(this List<int> l)
        {
            int min = int.MaxValue;
            for (int i = 0; i < l.Count; i++)
                if (l[i] < min)
                    min = l[i];
            return min;
        }
        public static int FindOccurences(this List<int> l, int match)
        {
            int result = 0;
            for (int i = 0; i < l.Count; i++)
                if (l[i] == match)
                    result++;
            return result;
        }

        public static double Max(this List<double> l)
        {
            double max = double.MinValue;
            for (int i = 0; i < l.Count; i++)
                if (l[i] > max)
                    max = l[i];
            return max;
        }
        public static double Min(this List<double> l)
        {
            double min = double.MaxValue;
            for (int i = 0; i < l.Count; i++)
                if (l[i] < min)
                    min = l[i];
            return min;
        }

        public static List<List<decimal>> Copy(this List<List<decimal>> l)
        {
            List<List<decimal>> result = new List<List<decimal>>();
            for (int i = 0; i < l.Count; i++)
            {
                List<decimal> newItem = new List<decimal>();
                for (int j = 0; j < l[i].Count; j++)
                    newItem.Add(l[i][j]);
                result.Add(newItem);
            }
            return result;
        }

        public static int OneOrGreater(this double d)
        {
            int i = (int)d;
            if (d < 1)
                i = 1;
            return i;
        }
        public static int OneOrGreater(this int a)
        {
            int i = a;
            if (a < 1)
                i = 1;
            return i;
        }
        public static int ZeroOrGreater(this int a)
        {
            int i = a;
            if (a < 0)
                i = 0;
            return i;
        }
        public static int WithinBounds(this int i, int min, int max)
        {
            if (i < min) return min;
            else if (i > max) return max;
            return i;
        }

        public static T[] GetInnerArray<T>(this T[,] ar, int innerArrayIndex)
        {
            T[] innerAr = new T[ar.GetLength(1)];
            for (int i = 0; i < innerAr.Length; i++)
                innerAr[i] = ar[innerArrayIndex, i];
            return innerAr;
        }
        public static int[] GetLengths<T>(this List<T[]> l)
        {
            int[] lengths = new int[l.Count];
            for (int i = 0; i < l.Count; i++)
                lengths[i] = l[i].Length;
            return lengths;
        }
        public static int[] GetLengths<T>(this T[,] ar)
        {
            int[] lengths = new int[ar.Length];
            for (int i = 0; i < ar.Length; i++)
                lengths[i] = ar.GetInnerArray(i).Length;
            return lengths;
        }

        public static List<T> InsertAtStart<T>(this List<T> a, T item)
        {
            if (a != null)
            {
                a.Insert(0, item);
                return a;
            }
            else return new List<T> { item };
        }
        public static List<T> MoveElement<T>(this List<T> a, int from, int to)
        {
            a.Insert(to, a[from]);
            a.RemoveAt(from + (from > to ? 1 : 0));
            return a;
        }
        public static List<T> MoveElementToEnd<T>(this List<T> a, int from)
        {
            a.Insert(a.Count, a[from]);
            a.RemoveAt(from);
            return a;
        }
        public static List<T> MoveElementToStart<T>(this List<T> a, int from)
        {
            a.Insert(0, a[from]);
            a.RemoveAt(from + 1);
            return a;
        }
        public static List<T> Swap<T>(this List<T> l, int a, int b)
        {
            T t = l[a];
            l[a] = l[b];
            l[b] = t;
            return l;
        }

        public static bool ContainsOrdered(this List<bool> list, List<bool> containedList)
        {
            for (int i = 0; i < list.Count - containedList.Count; i++)
            {
                bool found = true;
                for (int j = 0; j < containedList.Count && found; j++)
                    found = list[i + j] == containedList[j];
                if (found) return true;
            }
            return false;
        }
        public static bool ContainsOrdered(this List<int> list, List<int> containedList)
        {
            for (int i = 0; i < list.Count - containedList.Count; i++)
            {
                bool found = true;
                for (int j = 0; j < containedList.Count && found; j++)
                    found = list[i + j] == containedList[j];
                if (found) return true;
            }
            return false;
        }
        public static bool ContainsOrdered(this List<float> list, List<float> containedList)
        {
            for (int i = 0; i < list.Count - containedList.Count; i++)
            {
                bool found = true;
                for (int j = 0; j < containedList.Count && found; j++)
                    found = list[i + j] == containedList[j];
                if (found) return true;
            }
            return false;
        }

        public static int[] GetIndicesOfMatchingValues(this bool[] a, bool value)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < a.Length; i++)
                if (a[i] == value)
                    indices.Add(i);
            return indices.ToArray();
        }

        public static int[] GetInt32ArrayFromMultidimensionalInt32Array(int[,] a, int dimension, int index)
        {
            int[] ar = new int[a.GetLength(dimension)];
            for (int i = 0; i < ar.Length; i++)
            {
                if (dimension == 0)
                    ar[i] = a[index, i];
                else if (dimension == 1)
                    ar[i] = a[i, index];
            }
            return ar;
        }
        public static int[] ToInt32Array(this bool[] a)
        {
            int[] ar = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                ar[i] = Convert.ToInt32(a[i]);
            return ar;
        }
        public static int[] ToInt32Array(this string[] s)
        {
            int[] ar = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
                ar[i] = Convert.ToInt32(s[i]);
            return ar;
        }
        public static int[,] ToInt32Array(this string[,] s)
        {
            int a = s.Length;
            int b = s.GetLengths().Max();
            int[,] ar = new int[a, b];
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    ar[a, b] = Convert.ToInt32(s[a, b]);
            return ar;
        }
        public static double[,] ToDoubleArray(this string[,] s)
        {
            int a = s.Length;
            int b = s.GetLengths().Max();
            double[,] ar = new double[a, b];
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    ar[i, j] = Convert.ToDouble(s[i, j]);
            return ar;
        }
        public static decimal[] ToDecimalArray(this string[] s)
        {
            decimal[] ar = new decimal[s.Length];
            for (int i = 0; i < s.Length; i++)
                ar[i] = Convert.ToDecimal(s[i]);
            return ar;
        }
        public static decimal[,] ToDecimalArray(this string[,] s)
        {
            int a = s.GetLength(0);
            int b = s.GetLength(1);
            decimal[,] ar = new decimal[a, b];
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    ar[i, j] = Convert.ToDecimal(s[i, j]);
            return ar;
        }
        public static bool[] ToBooleanArray(this string[] s)
        {
            bool[] ar = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
                ar[i] = Convert.ToBoolean(s[i]);
            return ar;
        }
        public static bool[] ToBooleanArray(this int[] a)
        {
            bool[] ar = new bool[a.Length];
            for (int i = 0; i < a.Length; i++)
                ar[i] = Convert.ToBoolean(a[i]);
            return ar;
        }
        public static string[] ToStringArray(this int[] a)
        {
            string[] result = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i].ToString();
            return result;
        }
        public static string[] ToStringArray(this decimal[] a)
        {
            string[] result = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i].ToString();
            return result;
        }
        public static string[] ToStringArray(this double[] a)
        {
            string[] result = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
                result[i] = a[i].ToString();
            return result;
        }
        public static List<List<T>> ToList<T>(this T[,] ar)
        {
            List<List<T>> l = new List<List<T>>();
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                List<T> temp = new List<T>();
                for (int j = 0; j < ar.GetLength(1); j++)
                    temp.Add(ar[i, j]);
                l.Add(temp);
            }
            return l;
        }
        public static List<int> ToInt32List(this string[] s)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < s.Length; i++)
                result.Add(Convert.ToInt32(s[i]));
            return result;
        }
    }
}