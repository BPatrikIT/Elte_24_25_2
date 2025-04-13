module Hazi8 where
    data Base = A | T | G | C deriving (Show, Eq)

    isComplement :: [Base] -> [Base] -> Bool
    isComplement [] [] = True
    isComplement [] _ = False
    isComplement _ [] = False
    isComplement (x:xs) (y:ys) = (complementBase x == y) && isComplement xs ys
        where
            complementBase A = T
            complementBase T = A
            complementBase G = C
            complementBase C = G

    data Transaction
        = Transfer Int Int
        | Purchase Int
        | Receive Int Int String
        deriving (Show)

    netGain :: [Transaction] -> Int
    netGain = foldr calculate 0
        where
            calculate (Transfer amount _) acc = acc - amount
            calculate (Purchase amount) acc = acc - amount
            calculate (Receive amount _ _) acc = acc + amount

    wasNegative :: [Transaction] -> Bool
    wasNegative transactions = any (< 0) (scanl updateBalance 0 transactions)
        where
            updateBalance acc (Transfer amount _) = acc - amount
            updateBalance acc (Purchase amount) = acc - amount
            updateBalance acc (Receive amount _ _) = acc + amount