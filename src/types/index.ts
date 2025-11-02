/**
 * Type definitions for the UMECA Bulletin Board System
 * @module types
 */

/**
 * Represents a bulletin/announcement in the system
 */
export interface Bulletin {
  /** Unique identifier for the bulletin */
  Id: number;
  
  /** Title of the bulletin */
  Title: string;
  
  /** Author of the bulletin (optional) */
  Author?: string;
  
  /** Main content/body of the bulletin */
  Content: string;
  
  /** Status code (1 = active, 0 = inactive) */
  Status: number;
  
  /** Date and time when the bulletin was published */
  DatePublished: string;
  
  /** Number of attached files (optional) */
  FileCount?: number;
  
  /** Whether the bulletin is archived (optional) */
  IsArchived?: boolean;
}

/**
 * Props for the CarouselOrientation component
 */
export interface BulletinCarouselProps {
  /** Array of bulletins to display in the carousel */
  bulletinData: Bulletin[];
}

/**
 * API Response type for bulletin endpoints
 */
export interface BulletinApiResponse {
  /** Array of bulletins */
  data?: Bulletin[];
  
  /** Error message if request failed */
  error?: string;
  
  /** Additional error details */
  details?: string;
}

/**
 * Database configuration type
 */
export interface DatabaseConfig {
  /** Database server address */
  server: string;
  
  /** Database name */
  database: string;
  
  /** Connection options */
  options: {
    /** Whether to use encryption */
    encrypt: boolean;
    
    /** Whether to trust server certificate */
    trustServerCertificate: boolean;
    
    /** Enable arithmetic abort */
    enableArithAbort: boolean;
    
    /** SQL Server instance name */
    instanceName?: string;
  };
  
  /** Connection timeout in milliseconds */
  connectionTimeout: number;
  
  /** Request timeout in milliseconds */
  requestTimeout: number;
  
  /** Connection pool configuration */
  pool: {
    /** Maximum number of connections */
    max: number;
    
    /** Minimum number of connections */
    min: number;
    
    /** Idle timeout in milliseconds */
    idleTimeoutMillis: number;
  };
}
