CREATE FUNCTION CalculateTotalPrice
(
    @UnitPrice DECIMAL(10, 2),
    @Quantity INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TotalPrice DECIMAL(10, 2)

    SET @TotalPrice = @UnitPrice * @Quantity

    RETURN @TotalPrice
END