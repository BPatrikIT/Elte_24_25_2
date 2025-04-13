module Hazi7Gyak where
    alternatingSum :: [Int] -> Int
    alternatingSum [] = 0
    alternatingSum [x] = x
    alternatingSum [x,y] = x-y
    alternatingSum (x:y:xs) = x-y + alternatingSum xs

    changeYear :: String -> String
    changeYear [] = []
    changeYear ('2':'0':'2':'4':xs) = "2025" ++ changeYear xs
    changeYear (x:xs) = x : changeYear xs 