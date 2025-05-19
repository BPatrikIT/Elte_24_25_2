module Week11 where
    pointsCalculator :: Integral a => (a, a) -> (a)
    pointsCalculator (x, y) = 100 - y - (x `div` 2)

    points :: Integral a => [(String, a, a)] -> [(String, a)]
    points [] = []
    points ((name, x, y):xs)
      | p > 0     = (name, p) : points xs
      | otherwise = points xs
      where p = pointsCalculator (x, y)


    type Apple = (Bool, Int)
    type Tree = [Apple]
    type Garden = [Tree]

    ryuksApples :: Garden -> Int
    ryuksApples garden = length [() | tree <- garden, (ripe, height) <- tree, ripe, height <= 3]

    doesContain :: String -> String -> Bool
    doesContain [] _ = True
    doesContain _ [] = False
    doesContain (c:cs) (x:xs)
        | c == x    = doesContain cs xs
        | otherwise = doesContain (c:cs) xs

    