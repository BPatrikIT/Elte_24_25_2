module Week7 where
    
    numberWords' :: Num a => String -> [(a, String)]
    numberWords' xs = numberHelper (words xs) 1
        where
            numberHelper [] _ = []
            numberHelper (x:xs) n = (n, x) : numberHelper xs (n + 1)

    intersperse' :: Eq a => [a] -> a -> [a]
    intersperse' [] _ = []
    intersperse' [x] _ = [x]
    intersperse' (x:xs) y = x : y : intersperse' xs y