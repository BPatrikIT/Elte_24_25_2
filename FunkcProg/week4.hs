module Week4 where
    add1 :: Num a => [a] -> [a]
    add1 (x:xs) = [y+1 | y <- x:xs]