CREATE PROCEDURE [msg].[spCheckLabelHost]
  @Host NVARCHAR(256)
AS
BEGIN
  DECLARE @LabelId INT;
  SELECT
    @LabelId = [LabelId]
  FROM [acc].[LabelHost] WITH(NOLOCK)
  WHERE [Host] = @Host

  SELECT CASE WHEN @LabelId IS NULL THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END
END