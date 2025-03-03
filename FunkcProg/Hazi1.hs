module Hazi1 where
    intExpr1 :: Int
    intExpr1 = 5

    intExpr2 :: Int
    intExpr2 = 10

    intExpr3 :: Int
    intExpr3 = 15

    charExpr1 :: Char
    charExpr1 = 'a'

    charExpr2 :: Char
    charExpr2 = 'b'

    charExpr3 :: Char
    charExpr3 = 'c'

    boolExpr1 :: Bool
    boolExpr1 = True

    boolExpr2 :: Bool
    boolExpr2 = False

    boolExpr3 :: Bool
    boolExpr3 = 5 > 3

    inc :: Integer -> Integer
    inc x = x + 1

    triple :: Integer -> Integer
    triple x = x * 3

    thirteen1 :: Integer
    thirteen1 = inc (triple 4) + 1

    thirteen2 :: Integer
    thirteen2 = triple (inc 3) + 1

    thirteen3 :: Integer
    thirteen3 = inc (inc (triple 4))

    cmpRem5Rem7 :: Integer -> Bool
    cmpRem5Rem7 x = (x `mod` 5) > (x `mod` 7)