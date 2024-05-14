# Number Words

Intermediate level task for practicing loops, selection statements (`if` and `switch`), `switch` expression and work with strings.

Estimated time to complete the task - 1.5h.

The task requires .NET 6 SDK installed.


## Task Description

In this task you have to implement three static methods that returns the string representation of a given number. To simplify the development process, you can use the methods of the [Math class](https://docs.microsoft.com/en-us/dotnet/api/system.math) in your code.


### 1. The If Statement

Implement the [ConvertInteger](NumberWords/Converter.cs#L13) method that returns the string representation of the `number` argument. The method should use the [operator + to concatenate strings](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#-and--operators).

```
1234567890 => "one two three four five six seven eight nine zero"
```

Use the [if statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-if-statement) and iteration statements to implement this method. Don't use *collections* here.


### 2. The Switch Statement

Implement the [ConvertDecimal](NumberWords/Converter.cs#L23) method that writes the string representation of the `number` argument to the `stringBuiler`. The method should use the `StringBuilder` class to [concatenate a result string](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#stringbuilder).

```
12345.6789 => "one two three four five point six seven eight nine"
```

Use the [switch statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement) and iteration statements to implement this method. You can use *collections* here.


### 3. The Switch Expression

Implement the [ConverDouble](NumberWords/Converter.cs#L34) method that returns the string representation of the `number` argument. The method should concatenate string digits with [string interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/concatenate-multiple-strings#string-interpolation).

```
12345.6789d => "One two three four five point six seven eight nine"
```

Use the [switch expression](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression) and iteration statements to implement this method. You can use *collections* here.


## Questions

1. Compare the three approaches of string concatenation:
    * The string concatenation using the operator +.
    * The string concatenation using the `StringBuilder` class.
    * The string concatenation using string interpolation.

Which string concatenation approach is the best for this task?

2. What is the difference between the `switch` statement and the `switch` expression?

3. Compare the usages of the `switch` statement and the `switch` expression with the usage of the `if` statement. What are the benefits of the `switch` statement and the `switch` expression over the `if` statement?

Discuss your answer with a trainer or mentor, if you work in a regular group.
