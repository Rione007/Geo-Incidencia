namespace Backend_Geo_Incidencia.Shared
{
    public class DbConstantes
    {
        public const string SpLoginUsuario = "dbo.SP_LOGIN_USUARIO";
        public const string SpObtenerCuentaId = "dbo.SP_OBTENER_CUENTA_POR_ID";
        public const string SpCrearCuenta = "dbo.SP_CREAR_CUENTA";
        public const string SpActualizarCuenta = "dbo.SP_ACTUALIZAR_USUARIO";

        public const string SpListarTipos = "dbo.SP_LISTAR_TIPOS_INCIDENCIA";
        public const string SpObtenerTipoPorId = "dbo.SP_OBTENER_TIPO_POR_ID";

        public const string SpListarSubtipos = "dbo.SP_LISTAR_SUBTIPOS";
        public const string SpObtenerSubtipoPorId = "dbo.SP_OBTENER_SUBTIPO_POR_ID";

        public const string SpRegistrarIncidencia = "dbo.SP_REGISTRAR_INCIDENCIA";
        public const string SpObtenerIncidenciaPorId = "dbo.SP_OBTENER_INCIDENCIA_POR_ID";
        public const string SpListarIncidenciasPorUsuarioId = "dbo.SP_LISTAR_INCIDENCIAS_POR_USUARIO_ID";
        public const string SpListarIncidencias = "SP_LISTAR_INCIDENCIAS";


        //faltan apis
        public const string SpBuscarIncidenciasPorArea = "dbo.SP_INCIDENCIAS_BUSCAR_POR_AREA";
        public const string SpBuscarIncidenciasPorRadio = "dbo.SP_INCIDENCIAS_BUSCAR_POR_RADIO";
        public const string SpObtenerHeatmap = "dbo.SP_INCIDENCIAS_OBTENER_HEATMAP";



    }
}
