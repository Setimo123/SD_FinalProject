# UMECA Bulletin Board - Architecture Overview

This document provides a high-level overview of the UMECA Bulletin Board System architecture, explaining how different components interact and the design decisions behind the system.

## System Architecture

The UMECA Bulletin Board System follows a three-tier architecture:

```
┌─────────────────────────────────────────────────────────┐
│                    Presentation Layer                    │
│            (Next.js 15 + React 19 + Tailwind)           │
│  - Web UI with carousel display                         │
│  - Real-time clock and date components                  │
│  - Responsive design with gradient backgrounds          │
└──────────────────┬──────────────────────────────────────┘
                   │ HTTP/REST API
┌──────────────────▼──────────────────────────────────────┐
│                  Application Layer                       │
│                  (C# .NET API Bridge)                   │
│  - REST API endpoints                                   │
│  - Data transformation and validation                   │
│  - Connection to database                               │
└──────────────────┬──────────────────────────────────────┘
                   │ ADO.NET / EF
┌──────────────────▼──────────────────────────────────────┐
│                     Data Layer                          │
│              (SQL Server LocalDB)                       │
│  - Bulletins table                                      │
│  - Persistent storage                                   │
└─────────────────────────────────────────────────────────┘
```

## Component Breakdown

### Frontend (Next.js Application)

#### 1. **Pages**
- `src/app/page.tsx` - Home page that fetches and displays bulletins
- `src/app/layout.tsx` - Root layout with header, logo, and time display

#### 2. **Components**
- `src/app/_components/bulletin.tsx` - Main carousel component
- `src/app/_components/timeclock.tsx` - Real-time clock display
- `src/app/_components/currentDate.tsx` - Current date display
- `src/components/ui/` - Reusable UI components (cards, carousel, buttons)

#### 3. **API Routes**
- `src/app/api/bulletin/route.ts` - Next.js API route that proxies to C# API

#### 4. **Utilities**
- `src/lib/utils.ts` - Helper functions (Tailwind class merging)
- `src/lib/constants.ts` - Application constants
- `src/types/index.ts` - TypeScript type definitions

### Backend (C# API Server)

#### Files
- `BulletinApiServer.cs` - Main API server implementation
- `CSharp-API-Bridge.cs` - Database connection bridge
- `Program.cs-example` - Example program template

#### Endpoints
- **GET** `/api/bulletin` - Fetch all active bulletins
- **POST** `/api/bulletin` - Create a new bulletin

### Database (SQL Server LocalDB)

#### Tables

**Bulletins Table Schema:**
```sql
CREATE TABLE Bulletins (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(100),
    Content NVARCHAR(MAX) NOT NULL,
    Status INT DEFAULT 1,
    DatePublished DATETIME NOT NULL,
    FileCount INT DEFAULT 0,
    IsArchived BIT DEFAULT 0
);
```

## Data Flow

### Fetching Bulletins (Read Operation)

```
User Browser
    ↓
Next.js Server (SSR)
    ↓ HTTP GET
Next.js API Route (/api/bulletin)
    ↓ HTTP GET
C# API Server (localhost:5000)
    ↓ SQL Query
SQL Server LocalDB
    ↓ Results
C# API Server (transforms data)
    ↓ JSON Response
Next.js API Route (forwards data)
    ↓ JSON Response
Next.js Server (renders page)
    ↓ HTML
User Browser (displays carousel)
```

### Creating a Bulletin (Write Operation)

```
Admin/Client
    ↓ POST Request
Next.js API Route (/api/bulletin)
    ↓ HTTP POST
C# API Server
    ↓ INSERT Query
SQL Server LocalDB
    ↓ Success/Error
C# API Server
    ↓ JSON Response
Next.js API Route
    ↓ JSON Response
Client (confirmation)
```

## Key Design Decisions

### 1. **Why Next.js?**
- **Server-Side Rendering**: Improves initial load time and SEO
- **API Routes**: Built-in API handling without separate server
- **React 19**: Modern UI framework with hooks and effects
- **TypeScript**: Type safety and better developer experience

### 2. **Why C# API Bridge?**
- **LocalDB Compatibility**: Node.js mssql package has limited LocalDB support
- **Separation of Concerns**: Database logic isolated from frontend
- **Reusability**: C# API can be used by other clients
- **Performance**: .NET is optimized for database operations

### 3. **Why Embla Carousel?**
- **Vertical Scrolling**: Supports vertical carousel orientation
- **Autoplay Plugin**: Built-in autoplay functionality
- **Customizable**: Highly configurable for specific needs
- **Lightweight**: Small bundle size

### 4. **Why Tailwind CSS?**
- **Utility-First**: Rapid UI development
- **Responsive**: Built-in responsive design utilities
- **Customizable**: Easy theme customization
- **No CSS Conflicts**: Scoped by design

## State Management

The application uses minimal state management:

### Client-Side State
- **Time/Date**: Updated every second using `setInterval`
- **Carousel API**: Managed by Embla Carousel
- **Mounted State**: Prevents hydration mismatches

### Server-Side State
- **Bulletins**: Fetched fresh on each page load (no caching)
- **Environment Variables**: Stored in `.env.local`

## Performance Considerations

### 1. **Caching Strategy**
- Bulletins: `cache: 'no-store'` for real-time updates
- Static Assets: Cached by Next.js automatically
- Images: Optimized with Next.js Image component

### 2. **Database Connection Pooling**
```typescript
pool: {
  max: 10,      // Maximum connections
  min: 0,       // Minimum connections
  idleTimeoutMillis: 30000  // 30 seconds
}
```

### 3. **Client-Side Optimizations**
- Lazy loading of components
- Minimal re-renders using React hooks
- Debounced updates for time/date

## Security Considerations

### 1. **SQL Injection Prevention**
- Use parameterized queries in C# API
- Never concatenate user input directly into SQL

### 2. **Environment Variables**
- Sensitive data stored in `.env.local` (not committed to git)
- Separate configurations for development and production

### 3. **CORS**
- C# API should restrict origins in production
- Only allow requests from known domains

### 4. **Input Validation**
- Validate bulletin data before database insertion
- Sanitize HTML content to prevent XSS attacks

## Scalability

### Current Limitations
- Single database instance (LocalDB)
- No caching layer
- Synchronous database operations

### Future Improvements
1. **Redis Caching**: Cache frequently accessed bulletins
2. **Database Replication**: Master-slave setup for read scaling
3. **CDN**: Serve static assets from CDN
4. **Load Balancing**: Multiple Next.js instances
5. **WebSockets**: Real-time updates without polling

## Testing Strategy

### Unit Tests
- Test utility functions
- Test data transformation logic
- Test API route handlers

### Integration Tests
- Test C# API endpoints
- Test database operations
- Test Next.js API routes

### End-to-End Tests
- Test complete user workflows
- Test carousel autoplay
- Test time/date updates

## Monitoring and Logging

### Current Logging
- Console logs with emoji prefixes (🔄, ✅, ❌)
- Error tracking in catch blocks
- API request/response logging

### Production Monitoring Recommendations
1. **Application Performance Monitoring (APM)**: New Relic, DataDog
2. **Error Tracking**: Sentry, Rollbar
3. **Log Aggregation**: ELK Stack, Splunk
4. **Uptime Monitoring**: Pingdom, UptimeRobot

## Deployment

### Development
```bash
npm run dev  # Next.js development server
dotnet run   # C# API server
```

### Production
```bash
npm run build  # Build optimized bundle
npm start      # Start production server
```

### Environment Variables (Production)
```env
NEXT_PUBLIC_BASE_URL=https://yourdomain.com
CS_API_URL=https://api.yourdomain.com/api/bulletin
NODE_ENV=production
```

## Technology Stack Summary

| Layer | Technology | Version | Purpose |
|-------|-----------|---------|---------|
| Frontend | Next.js | 15.4.5 | React framework with SSR |
| UI Library | React | 19.1.0 | Component-based UI |
| Styling | Tailwind CSS | 4.0 | Utility-first CSS |
| Language | TypeScript | 5.x | Type-safe JavaScript |
| Carousel | Embla Carousel | 8.6.0 | Carousel functionality |
| Date/Time | Day.js | 1.11.13 | Date formatting |
| Backend | C# .NET | Latest | API server |
| Database | SQL Server LocalDB | Latest | Data persistence |

## Folder Structure Explained

```
antoni-main/
├── src/                      # Source code
│   ├── app/                  # Next.js app directory
│   │   ├── _components/      # Page-specific components
│   │   ├── api/              # API routes
│   │   ├── layout.tsx        # Root layout
│   │   ├── page.tsx          # Home page
│   │   └── globals.css       # Global styles
│   ├── components/           # Reusable components
│   │   └── ui/               # UI components
│   ├── lib/                  # Utilities and configs
│   │   ├── constants.ts      # Constants
│   │   ├── db.ts             # Database config
│   │   └── utils.ts          # Helper functions
│   └── types/                # TypeScript types
│       └── index.ts          # Type definitions
├── public/                   # Static assets
│   └── logo.png              # UMECA logo
├── docs/                     # Documentation
│   ├── SETUP.md              # Setup guide
│   └── ARCHITECTURE.md       # This file
├── BulletinApiServer.cs      # C# API server
├── CSharp-API-Bridge.cs      # Database bridge
├── .env.example              # Environment template
├── package.json              # Node dependencies
├── tsconfig.json             # TypeScript config
├── next.config.ts            # Next.js config
├── tailwind.config.ts        # Tailwind config
└── README.md                 # Main documentation
```

## Conclusion

The UMECA Bulletin Board System is designed with simplicity, maintainability, and extensibility in mind. The three-tier architecture ensures clear separation of concerns, making it easy to update individual components without affecting others.

---

**For questions or improvements, contact the development team.**
