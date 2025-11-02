// lib/db.ts
import sql from 'mssql';

// LocalDB doesn't work well with Node.js mssql package
// We need to use a workaround or SQL Server Express
const config: sql.config = {
  server: 'localhost',
  database: 'ConsultationDatabase',
  options: {
    encrypt: false,
    trustServerCertificate: true,
    enableArithAbort: true,
    instanceName: 'MSSQLLocalDB',
  },
  connectionTimeout: 30000,
  requestTimeout: 30000,
  pool: {
    max: 10,
    min: 0,
    idleTimeoutMillis: 30000
  }
};

let pool: sql.ConnectionPool | null = null;

export async function getConnection() {
  try {
    if (!pool) {
      console.log('🔄 Attempting to connect to SQL Server LocalDB...');
      console.log('Server:', config.server);
      console.log('Database:', config.database);
      
      pool = await sql.connect(config);
      console.log('✅ Connected to SQL Server LocalDB successfully!');
    }
    return pool;
  } catch (err: any) {
    console.error('❌ DB connection error:');
    console.error('Error message:', err?.message);
    console.error('Error code:', err?.code);
    console.error('Full error:', err);
    throw err;
  }
}

export { sql };
