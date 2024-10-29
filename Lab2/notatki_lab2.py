from functools import reduce


numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9]
newNumber = [x ** 2 for x in numbers if x % 2 == 0]
print(newNumber)

newNumber1  = list(map(lambda x: x ** 2, numbers))
print(newNumber1)

newNumber2  = list(filter(lambda x: x % 2 == 0, numbers))
print(newNumber2)

newNumber3  = reduce(lambda x, y: x + y, numbers)
print(newNumber3)

a = 13
input = "3+2*1-a"
output = eval(input)
print(output)


#code = ```
#    def greet(name):
#        return "Hello, " + name
#
#    result = greet("World)"
#```

global_context = {}
local_context = {}
exec("x = 10", global_context, local_context)
print(local_context['x'])
