module Hazi4 where
    -- 1. Jelszó
    password :: [Char] -> [Char]
    password xs = [ '*' | _ <- xs ]

    -- 2. Növekvő párok
    filterIncPairs :: Ord a => [(a, a)] -> [(a, a)]
    filterIncPairs xs = [ (a, b) | (a, b) <- xs, a < b ]

    -- 3. Nagybetűs szavak
    startsWithUpper :: [String] -> [String]
    startsWithUpper xs = [ word | word@(c:_) <- xs, c `elem` ['A'..'Z'] ]

    -- 4. Egy elemű listák
    onlySingletons :: [[a]] -> [[a]]
    onlySingletons xs = [ x | x@[_] <- xs ]