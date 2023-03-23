javascript.md
# Javascript

## interpreted by the browser engine at runtime. 

##Javascript Types 
- Dynamic, weak typing
- String 'sting this stuff' "double or single" 'you can have"boop" double qotes inside of the other'
- Undefinded
- Number 0,1,-1,100
- Boolean
- Object
- Null
- Bigint
- Symbol


-'Sunbons'

## Comparison
-== : type coerces
-=== : strinc comparison (compares not only the values, but also the the type)
- '1' == 1 : true
- '1' === 1 : false

## Scopes
- global scope (in browser, )
- function scope 
- block scope 

- var will leave var scope even if it seems like it should not unless it is in a function. 

            //when you declare a a value with var
            //global scope
            var foo = 'bar'
            //function scope, not global
            function example(){var bar = 'foo'
            }


## Declaratives
- var = store any values that may change in the future. old school
- let = storing any values that may change in the future. the new new
- const = values that do n0t change
- advantage of let over var is that it is block scoped

## Truely and falsey values
- falsey values : FUNONE (false, undefined, null, 0, NaN, EmptyString)
- 0 is falsey
- anything else is a Truely value 


## ;
- you do not need to use the semicoloin unless you have more than one command on a line.
- 

## document object model
- this is somthing about the style of how the html page is structured 
- dom is a data structure that represents an html page 
- access dom in js as document object. 

## events 
- <button onclick ="console.log('penut butter')"> "Click ME"</button>
- onmouseover
- onmouseleave
- onmouse
- bubbles out of the scope of the current body position, it will go to parent and there parent and so on until it reaches the body. 
- we can use stopPropogation()

