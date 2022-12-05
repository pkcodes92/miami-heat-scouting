// <copyright file="OutputParameter{TValue}.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Data
{
    /// <summary>
    /// This extension will help to cast the results to a particular type.
    /// </summary>
    /// <typeparam name="TValue">The value to cast the results to.</typeparam>
    public class OutputParameter<TValue>
    {
        /// <summary>
        /// This is the value to return.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1401 // Fields should be private
        public TValue value;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private bool valueSet = false;

        /// <summary>
        /// Gets the value to be casted.
        /// </summary>
        public TValue Value
        {
            get
            {
                if (!this.valueSet)
                {
                    throw new InvalidOperationException("Value not set");
                }

                return this.Value;
            }
        }

        /// <summary>
        /// Sets the value being casted from the database results.
        /// </summary>
        /// <param name="value">The object defining the necessary results.</param>
        internal void SetValue(object value)
        {
            this.valueSet = true;
            this.value = value == null || Convert.IsDBNull(value) ? default(TValue) ! : (TValue)value;
        }
    }
}
