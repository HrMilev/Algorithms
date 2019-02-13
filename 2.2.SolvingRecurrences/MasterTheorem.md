We have three cases:

1. if f(n) = O(n^(logb(a)-x)) for x>0, then T(n) = theta(n^(logb(a)))

2.if f(n) = theta(n^(logb(a))) , then T(n) = theta(n^(logb(a)*lg(n)))

3.if f(n) = omega(n^(logb(a)+x)) for x >0, then T(n) = theta(f(n))

In our example:

f(n) = theta(n^(logb(a)));

f(n) = theta(n^(log2(2))); -> f(n) = theta(n), then T(n) = theta(n*lg(n))
