//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.GridLengthSpecs
{
    using System;

    using Machine.Specifications;

    public abstract class a_GridLength
    {
        protected static GridLength gridLength;

        private Establish context = () => gridLength = new GridLength();
    }

    [Subject(typeof(GridLength))]
    public class when_initialized
    {
        private static GridLength gridLength;

        private Because of = () => gridLength = new GridLength();

        private It should_default_to_a_unit_type_of_auto = () => gridLength.GridUnitType.ShouldEqual(GridUnitType.Auto);

        private It should_default_to_a_value_of_zero = () => gridLength.Value.ShouldEqual(0);
    }

    [Subject(typeof(GridLength))]
    public class when_initialized_with_a_value_that_is_not_a_number
    {
        private static Exception exception;

        private Because of = () => exception = Catch.Exception(() => new GridLength(double.NaN));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<ArgumentException>();
    }

    [Subject(typeof(GridLength))]
    public class when_initialized_with_a_value_that_is_infinite
    {
        private static Exception exception;

        private Because of = () => exception = Catch.Exception(() => new GridLength(double.PositiveInfinity));

        private It should_throw_an_exception = () => exception.ShouldBeOfType<ArgumentException>();
    }

    [Subject(typeof(GridLength))]
    public class when_initialized_with_a_value
    {
        private const double ExpectedValue = 10;

        private static GridLength gridLength;

        private Because of = () => gridLength = new GridLength(ExpectedValue);

        private It should_have_a_unit_type_of_pixel = () => gridLength.GridUnitType.ShouldEqual(GridUnitType.Pixel);

        private It should_have_the_value_specified = () => gridLength.Value.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(GridLength))]
    public class when_initialized_with_a_value_and_a_unit_type_of_auto
    {
        private const double ExpectedValue = 1;

        private static GridLength gridLength;

        private Because of = () => gridLength = new GridLength(10, GridUnitType.Auto);

        private It should_have_a_unit_type_of_auto = () => gridLength.GridUnitType.ShouldEqual(GridUnitType.Auto);

        private It should_have_the_value_of_one = () => gridLength.Value.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(GridLength))]
    public class when_asked_for_an_auto_gridlength
    {
        private static GridLength gridLength;

        private Because of = () => gridLength = GridLength.Auto;

        private It should_return_a_grid_length_with_GridUnitType_of_auto =
            () => gridLength.GridUnitType.ShouldEqual(GridUnitType.Auto);

        private It should_return_a_grid_length_with_unit_value = () => gridLength.Value.ShouldEqual(1);
    }
}