let fib n =
    let rec innerFib n a b =
        if n = 0 then a
        else if n = 1 then b
        else innerFib (n-1) b (a+b)
    innerFib n 0 1