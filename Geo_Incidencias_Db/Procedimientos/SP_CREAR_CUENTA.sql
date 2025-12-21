CREATE PROCEDURE [dbo].[SP_CREAR_CUENTA]
    @EMAIL         NCHAR(25),
    @CONTRASENA_HASH       VARCHAR(255),
    @NOMBRE         VARCHAR(80)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_USUARIO INT = 0;
    DECLARE @FILA INT = 0;
    DECLARE @ERROR INT = 0;
    DECLARE @MENSAJE NVARCHAR(200) = '';

    BEGIN TRY
        BEGIN TRAN;

        -- Verificar si ya existe una cuenta con el mismo nombre
        IF EXISTS (SELECT 1 FROM USUARIO WHERE RTRIM(LTRIM(EMAIL)) = RTRIM(LTRIM(@EMAIL)))
        BEGIN
            SET @MENSAJE = 'La Correo ya existe.';
            SET @ERROR = 1;
        END
        ELSE
        BEGIN
            INSERT INTO USUARIO (
                NOMBRE,
                EMAIL,
                CONTRASENA_HASH
            )
            VALUES (
            @NOMBRE,
            @EMAIL,
            @CONTRASENA_HASH
            );

            SET @FILA = @@ROWCOUNT;
            SET @ID_USUARIO = SCOPE_IDENTITY();
            SET @MENSAJE = 'Cuenta creada correctamente.';
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        SET @ERROR = ERROR_NUMBER();
        SET @MENSAJE = ERROR_MESSAGE();
    END CATCH;

    SELECT 
        @ID_USUARIO AS ID,
        @FILA AS FILA, --1 si es todo good 0 si esta mal
        @ERROR AS ERROR,  --  0 si esta mal 
        @MENSAJE AS MENSAJE;
END;

