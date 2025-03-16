module Week5 where
    sum' :: Num a => [a] -> a
    sum' [] = 0
    sum' [x] = x
    sum' (x:xs) = x + sum' xs

    product' :: Num a => [a] -> a
    product' [] = 1
    product' [x] = x
    product' (x:xs) = x * product' xs

    elem' :: Eq a => a -> [a] -> Bool
    elem' _ [] = False
    elem' y (x:xs) = (y == x) || elem' y xs

    concat' :: [[a]] -> [a]
    concat' [] = []
    concat' [x] = x
    concat' (x:xs) = x ++ concat' xs

    (+++) :: [a] -> [a] -> [a]
    [] +++ ys = ys
    (x:xs) +++ ys = x : (xs +++ ys)

    slowReverse :: [[a]] -> [a]
    slowReverse [] = []
    slowReverse (x:xs) = slowReverse xs +++ x

    repeat' :: a -> [a]
    repeat' x = x : repeat' x

    last' :: [a] -> a
    last' [x] = x
    last' (x:xs) = last' xs

    init' :: [a] -> [a]
    init' [x] = []
    init' (x:xs) = x : init' xs