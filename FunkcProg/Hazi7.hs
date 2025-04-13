module Hazi7 where

-- Páros-páratlan összeadás-kivonás
alternatingSum :: [Int] -> Int
alternatingSum = go 0
    where
        go _ [] = 0
        go i (x:xs)
            | even i    = x + go (i + 1) xs
            | otherwise = -x + go (i + 1) xs

-- Csak üres listák
onlyEmpties :: [[[a]]] -> Bool
onlyEmpties = all (all null)

-- Év váltó
changeYear :: String -> String
changeYear [] = []
changeYear ('2':'0':'2':'4':xs) = "2025" ++ changeYear xs
changeYear (x:xs) = x : changeYear xs

-- Ismétlődő szavak tömörítése
compress :: String -> String
compress = unwords . compressWords . words
    where
        compressWords [] = []
        compressWords (x:xs) = 
            let (repeats, rest) = span (== x) xs
                count = length repeats + 1
            in if count > 1
                then ("(" ++ show count ++ ")" ++ x) : compressWords rest
                else x : compressWords rest