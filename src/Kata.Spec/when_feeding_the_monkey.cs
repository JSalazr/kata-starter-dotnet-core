using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;
        
        Establish context = () => 
            _systemUnderTest = new Monkey();

        Because of = () => 
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_user_input_is_empty
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add(); };
        It should_return_0 = () => { _result.Should().Be(0); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_one_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("3"); };
        It should_return_same_number = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("2,2"); };
        It should_return_sum_of_numbers = () => { _result.Should().Be(4); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_is_unknown_amount
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,2,3"); };
        It should_return_sum_of_all = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_contains_new_line_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1\n2,3"); };
        It should_return_sum_of_all = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_contains_custom_single_character_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//;\n1;2"); };
        It should_return_sum_of_all = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_contains_one_negative_number
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Add("1,-2,3")); };
        It should_throw_an_exception = () => { _result.Message.Should().Be("Negatives not allowed: -2"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_contains_multiple_negatives
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result =Catch.Exception(()=> _systemUnderTest.Add("-1,-2,-3")); };
        It should_throw_an_exception = () => { _result.Message.Should().Be("Negatives not allowed: -1, -2, -3"); };
        static Calculator _systemUnderTest;
        static Exception _result;
    }

    public class when_user_input_contains_numbers_larger_than_1000
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("1,1001,2"); };
        It should_return_sum_of_numbers_less_than_1001 = () => { _result.Should().Be(3); };
        static Calculator _systemUnderTest;
        static int _result;
    }

    public class when_user_input_has_custom_multichar_delimiter
    {
        Establish _context = () =>
        {
            _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Add("//[***]\n1***2***3"); };
        It should_return_sum_of_all = () => { _result.Should().Be(6); };
        static Calculator _systemUnderTest;
        static int _result;
    }
}


//    10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
//    11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)
