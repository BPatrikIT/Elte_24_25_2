module Hazi3 where
    isSingleton :: [a] -> Bool
    isSingleton [_] = True
    isSingleton _   = False

    exactly2OrAtLeast4 :: [a] -> Bool
    exactly2OrAtLeast4 [_ , _] = True
    exactly2OrAtLeast4 (_:_:_:_:_) = True
    exactly2OrAtLeast4 _ = False

    firstTwoElements :: [a] -> [a]
    firstTwoElements (x:y:_) = [x, y]
    firstTwoElements _ = []

    withoutThird :: [a] -> [a]
    withoutThird (x:y:_:zs) = x : y : zs
    withoutThird xs = xs

    quadrupleToList :: (a, a, a, a) -> [a]
    quadrupleToList (a, b, c, d) = [a, b, c, d]

    insertSecond :: a -> [a] -> [a]
    insertSecond x (y:ys) = y : x : ys
    insertSecond _ [] = []

    firstPairToList :: [(a, a)] -> [a]
    firstPairToList ((a, b):_) = [a, b]
    firstPairToList [] = []