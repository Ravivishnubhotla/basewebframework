-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetProvinceID]
(
	-- Add the parameters for the function here
	@code nVarchar(50)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @rcode int

 
	SELECT @rcode = ID from dbo.SystemProvince where left(Code,3)=left(@code,3) 

	-- Return the result of the function
	RETURN @rcode

END
