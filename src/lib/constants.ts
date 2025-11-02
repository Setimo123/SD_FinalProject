/**
 * Application-wide constants and configuration values
 * @module constants
 */

/**
 * Carousel configuration constants
 */
export const CAROUSEL_CONFIG = {
  /** Auto-play delay in milliseconds (5 seconds) */
  AUTOPLAY_DELAY: 5000,
  
  /** Whether to stop on user interaction */
  STOP_ON_INTERACTION: false,
  
  /** Whether to stop on mouse enter */
  STOP_ON_MOUSE_ENTER: false,
  
  /** Whether to stop on last snap */
  STOP_ON_LAST_SNAP: false,
} as const;

/**
 * UI styling constants
 */
export const UI_CONFIG = {
  /** Maximum number of lines to display for bulletin titles */
  TITLE_LINE_CLAMP: 2,
  
  /** Maximum number of lines to display for bulletin content */
  CONTENT_LINE_CLAMP: 10,
  
  /** Logo dimensions in pixels */
  LOGO_SIZE: 400,
  
  /** Carousel content height calculation */
  CAROUSEL_HEIGHT: 'calc(100vh-300px)',
} as const;

/**
 * Time and date format constants
 */
export const TIME_FORMATS = {
  /** Time format: 12-hour with AM/PM (e.g., 02:45:30 PM) */
  TIME_12H: 'hh:mm:ss A',
  
  /** Full month name (e.g., November) */
  MONTH_FULL: 'MMMM',
  
  /** Day of month with leading zero (e.g., 03) */
  DAY_PADDED: 'DD',
  
  /** Full year (e.g., 2025) */
  YEAR_FULL: 'YYYY',
  
  /** Full weekday name (e.g., Monday) */
  WEEKDAY_FULL: 'dddd',
} as const;

/**
 * API configuration constants
 */
export const API_CONFIG = {
  /** Default base URL for the application */
  DEFAULT_BASE_URL: 'http://localhost:3000',
  
  /** Default C# API URL */
  DEFAULT_CS_API_URL: 'http://localhost:5000/api/bulletin',
  
  /** Bulletin API endpoint path */
  BULLETIN_ENDPOINT: '/api/bulletin',
} as const;

/**
 * Database configuration constants
 */
export const DB_CONFIG = {
  /** Default database server */
  DEFAULT_SERVER: 'localhost',
  
  /** Database name */
  DATABASE_NAME: 'ConsultationDatabase',
  
  /** SQL Server instance name */
  INSTANCE_NAME: 'MSSQLLocalDB',
  
  /** Connection timeout in milliseconds */
  CONNECTION_TIMEOUT: 30000,
  
  /** Request timeout in milliseconds */
  REQUEST_TIMEOUT: 30000,
  
  /** Maximum pool size */
  POOL_MAX: 10,
  
  /** Minimum pool size */
  POOL_MIN: 0,
  
  /** Pool idle timeout in milliseconds */
  POOL_IDLE_TIMEOUT: 30000,
} as const;

/**
 * Bulletin status codes
 */
export const BULLETIN_STATUS = {
  /** Inactive/Draft status */
  INACTIVE: 0,
  
  /** Active/Published status */
  ACTIVE: 1,
} as const;

/**
 * Application text content
 */
export const APP_TEXT = {
  /** Main application title */
  TITLE: 'UMECA BULLETIN BOARD',
  
  /** Project description */
  DESCRIPTION: 'a CpE 223/L Group Project',
  
  /** Bulletin overview card title */
  OVERVIEW_TITLE: 'Bulletin Overview',
  
  /** Text displayed when no bulletins are available */
  NO_BULLETINS: 'No bulletins available',
  
  /** Text displayed when there's an error loading bulletins */
  ERROR_LOADING: 'Error loading bulletins',
  
  /** Loading placeholder */
  LOADING: 'Loading...',
} as const;

/**
 * Gradient background configurations
 */
export const GRADIENT_PRESETS = {
  /** Current gradient: Coral to Magenta */
  CURRENT: 'linear-gradient(115deg, #ff512f, #dd2476)',
  
  /** Alternative gradient 1: Orange to Yellow-green */
  ALT_1: 'linear-gradient(319deg, #cd5700 0%, #fd9600 37%, #bfdd50 100%)',
  
  /** Alternative gradient 2: Gold to Sky blue */
  ALT_2: 'linear-gradient(115deg, #ffd700, #ed7014, #89cff0)',
} as const;
