module Hazi5 where
    -- 1. Hegy
    mountain :: Integral i => i -> String
    mountain 0 = ""
    mountain n = mountain (n - 1) ++ replicate (fromIntegral n) '#' ++ "\n"

    -- 2. 'a' karakterek egy szövegben
    countAChars :: Num i => String -> i
    countAChars [] = 0
    countAChars ('a':xs) = 1 + countAChars xs
    countAChars (_:xs) = countAChars xs

    -- 3. Lucas-sorozat
    lucas :: (Integral a, Num b) => a -> b
    lucas 0 = 2
    lucas 1 = 1
    lucas n = lucas (n - 1) + lucas (n - 2)

    -- 4. Hasznos függvény a jövőben
    longerThan :: Integral i => [a] -> i -> Bool
    longerThan [] n = n < 0
    longerThan (_:xs) n = negative n || longerThan xs (n - 1)

    negative :: (Ord i, Num i) => i -> Bool
    negative n = n < 0



    -- 5. Kiegészítés
    format :: Integral i => i -> String -> String
    format 0 xs = xs 
    format n [] = ' ' : format (n - 1) []
    format n (x:xs) = x : format (n - 1) xs

    -- 6. Összefésülés
    merge :: [a] -> [a] -> [a]
    merge [] ys = ys
    merge xs [] = xs
    merge (x:xs) (y:ys) = x : y : merge xs ys