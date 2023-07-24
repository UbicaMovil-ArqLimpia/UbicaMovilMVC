<?php

$serverName = "DESKTOP-NFDMETJ";
$connectionOptions = array(
    "Database" => "UbicaMovil",
);

// Establece la conexión
$conn = sqlsrv_connect($serverName, $connectionOptions);

if ($conn === false) {
    die(print_r(sqlsrv_errors(), true));
}

// Consulta para obtener los datos de la base de datos
$sql = "SELECT latitud, longitud, Nombre FROM Empresas"; // Cambia "nombre_de_la_tabla" por el nombre de tu tabla

$result = sqlsrv_query($conn, $sql);

if ($result === false) {
    die(print_r(sqlsrv_errors(), true));
}
// Preparar los datos para JSON
$markers = array();
while ($row = sqlsrv_fetch_array($result, SQLSRV_FETCH_ASSOC)) {
    $markers[] = $row;
}
echo "Datos obtenidos desde la base de datos:\n" . print_r($markers, true);

// Devolver los datos en formato JSON
header('Content-Type: application/json');
echo json_encode($markers);
sqlsrv_free_stmt($result);
sqlsrv_close($conn);
?>