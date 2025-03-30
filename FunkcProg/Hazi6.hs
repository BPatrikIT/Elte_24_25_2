module Hazi6 where

import Data.Char (toUpper, isDigit)

-- 1. Karakter-átalakítás
toUpperThird :: String -> String
toUpperThird (x:y:z:xs) = x : y : toUpper z : xs
toUpperThird xs = xs

-- 2. Rendezett-e
isSorted :: Ord a => [a] -> Bool
isSorted (x:y:xs) = x <= y && isSorted (y:xs)
isSorted _ = True

-- 3. Titkok tudója
cipher :: String -> String
cipher (a:b:c:xs) | isDigit c = [a, b]
cipher (_:xs) = cipher xs
cipher _ = ""

-- 4. Dupla elemek
doubleElements :: [a] -> [a]
doubleElements [] = []
doubleElements (x:xs) = x : x : doubleElements xs

-- 5. Sok szóköz
deleteDuplicateSpaces :: String -> String
deleteDuplicateSpaces = unwords . words
