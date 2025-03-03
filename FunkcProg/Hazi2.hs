module Hazi2 where
    addV :: (Double, Double) -> (Double, Double) -> (Double, Double)
    addV (x1, y1) (x2, y2) = (x1 + x2, y1 + y2)

    subV :: (Double, Double) -> (Double, Double) -> (Double, Double)
    subV (x1, y1) (x2, y2) = (x1 - x2, y1 - y2)

    scaleV :: Double -> (Double, Double) -> (Double, Double)
    scaleV s (x, y) = (s * x, s * y)

    scalar :: (Double, Double) -> (Double, Double) -> Double
    scalar (x1, y1) (x2, y2) = x1 * x2 + y1 * y2

    divides :: Integer -> Integer -> Bool
    divides 0 0 = True
    divides 0 _ = False
    divides x y = y `mod` x == 0

    add :: Integer -> Int -> Integer
    add x y = x + fromIntegral y