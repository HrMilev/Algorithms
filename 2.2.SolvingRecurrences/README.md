# SolvingRecurrences
The method for solving recurrences of the form : T(n) = aT(n/b) + f(n), where n is the size of a problem, a is division into subproblems and b is the size of a new subproblems. f(n) encompasses the cost of dividing the problem and combining the results of the subproblems.

Example:

For "FindMaxSubarray" we have:

a = 2 - we divide the problem in two recursive calls of "FindMaxSubarray" method.

b = 2 - we have split the array into two approximately equal subarrays.

f(n) = theta(n) - the method "FindMaxCrossingSubarray" takes theta(n) time.
