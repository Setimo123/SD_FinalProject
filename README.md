<div align="center">

# 📺 UMECA Bulletin TV

### *Where Information Comes Alive*

[![Next.js](https://img.shields.io/badge/Next.js-15.4.5-black?style=for-the-badge&logo=next.js)](https://nextjs.org)
[![React](https://img.shields.io/badge/React-19.1.0-blue?style=for-the-badge&logo=react)](https://react.dev)
[![TypeScript](https://img.shields.io/badge/TypeScript-5.0-3178C6?style=for-the-badge&logo=typescript)](https://www.typescriptlang.org)
[![Tailwind CSS](https://img.shields.io/badge/Tailwind-4.0-38B2AC?style=for-the-badge&logo=tailwind-css)](https://tailwindcss.com)

*A mesmerizing digital bulletin board that transforms campus announcements into an elegant visual experience.*

[✨ Demo](#-demo) • [🚀 Quick Start](#-quick-start) • [📖 Documentation](#-documentation) • [🤝 Contributing](#-team)

</div>

---

## 🎯 Overview

**UMECA Bulletin TV** is not just another bulletin board—it's a digital canvas that brings campus announcements to life. Built with cutting-edge web technologies, this system seamlessly blends form and function to create an engaging information display perfect for TV screens, kiosks, and digital signage.

Imagine walking through campus and seeing a sleek display with bulletins gracefully transitioning across the screen, complemented by a real-time clock and stunning gradient backgrounds. That's UMECA Bulletin TV.

### 🎨 Why UMECA Bulletin TV?

- 🌊 **Fluid Experience**: Buttery-smooth animations powered by Embla Carousel
- 🎭 **Visual Poetry**: Glass-morphism effects meet vibrant gradient backgrounds
- ⚡ **Lightning Fast**: Server-side rendering with Next.js 15 for instant loads
- 🔄 **Always Fresh**: Real-time data synchronization with SQL Server
- 📱 **Pixel Perfect**: Responsive design that looks stunning on any screen
- 🎯 **Zero Friction**: Auto-rotating carousel requires zero user interaction

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 🎪 Auto-Scrolling Carousel
Bulletins gracefully transition with smooth vertical animations, creating a captivating viewing experience that draws the eye.

### 📊 Smart Overview Card
A dedicated summary card provides instant visibility into all active bulletins at a glance.

### ⏰ Live Clock & Date
Real-time clock with elegant typography keeps viewers oriented in time and space.

</td>
<td width="50%">

### 🎨 Modern UI/UX
Stunning gradient backgrounds, glass-morphism cards, and carefully crafted animations create a premium feel.

### 🗄️ Robust Backend
SQL Server LocalDB integration via a custom C# API bridge ensures reliable data delivery.

### 📅 Timestamp Display
Each bulletin shows its publication date, helping users identify the most recent announcements.

</td>
</tr>
</table>

---

## 🚀 Quick Start

Get your bulletin board up and running in just a few minutes!



## 🛠️ Tech StackYou can start editing the page by modifying `app/page.tsx`. The page auto-updates as you edit the file.



### FrontendThis project uses [`next/font`](https://nextjs.org/docs/app/building-your-application/optimizing/fonts) to automatically optimize and load [Geist](https://vercel.com/font), a new font family for Vercel.

- **Framework**: Next.js 15.4.5 (React 19)

- **Language**: TypeScript## Learn More

- **Styling**: Tailwind CSS 4.0

- **UI Components**: Radix UITo learn more about Next.js, take a look at the following resources:

- **Carousel**: Embla Carousel with Autoplay

- **Date/Time**: Day.js- [Next.js Documentation](https://nextjs.org/docs) - learn about Next.js features and API.

- [Learn Next.js](https://nextjs.org/learn) - an interactive Next.js tutorial.

### Backend

- **Database**: SQL Server LocalDB (ConsultationDatabase)You can check out [the Next.js GitHub repository](https://github.com/vercel/next.js) - your feedback and contributions are welcome!

- **API Bridge**: C# .NET (BulletinApiServer.cs)

- **ORM**: ADO.NET / Entity Framework## Deploy on Vercel



## 📁 Project StructureThe easiest way to deploy your Next.js app is to use the [Vercel Platform](https://vercel.com/new?utm_medium=default-template&filter=next.js&utm_source=create-next-app&utm_campaign=create-next-app-readme) from the creators of Next.js.



```Check out our [Next.js deployment documentation](https://nextjs.org/docs/app/building-your-application/deploying) for more details.

antoni-main/
├── src/
│   ├── app/
│   │   ├── _components/          # Page-specific components
│   │   │   ├── bulletin.tsx      # Main carousel component
│   │   │   ├── timeclock.tsx     # Real-time clock display
│   │   │   └── currentDate.tsx   # Current date display
│   │   ├── api/
│   │   │   └── bulletin/
│   │   │       └── route.ts      # API route proxying to C# API
│   │   ├── layout.tsx            # Root layout with header
│   │   ├── page.tsx              # Home page
│   │   └── globals.css           # Global styles and theme
│   ├── components/
│   │   └── ui/                   # Reusable UI components
│   │       ├── button.tsx
│   │       ├── card.tsx
│   │       └── carousel.tsx
│   └── lib/
│       ├── db.ts                 # Database configuration
│       └── utils.ts              # Utility functions
├── public/
│   └── logo.png                  # UMECA logo
├── BulletinApiServer.cs          # C# API server
├── CSharp-API-Bridge.cs          # C# database bridge
└── Program.cs-example            # C# program template
```



### 📦 Prerequisites

Before you begin, make sure you have:

- **Node.js** 18.x or higher ([Download](https://nodejs.org))
- **npm** or **yarn** package manager
- **SQL Server LocalDB** ([Installation Guide](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb))
- **.NET SDK** for the C# API bridge

### 🎬 Installation

```bash
# Clone the repository
git clone https://github.com/Setimo123/SD_FinalProject.git
cd SD_FinalProject

# Install dependencies
npm install
# or
yarn install

# Start the development server
npm run dev
# or
yarn dev
```

🎉 **That's it!** Open [http://localhost:3000](http://localhost:3000) in your browser and watch the magic happen.

### 🗄️ Database Setup

1. **Create the database** using SQL Server Management Studio or command line:
   ```sql
   CREATE DATABASE ConsultationDatabase;
   
   -- Create Bulletins table
   USE ConsultationDatabase;
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

2. **Run the C# API Server** (required for database connectivity):
   ```bash
   dotnet run BulletinApiServer.cs
   ```

3. The API will automatically create the necessary tables and seed initial data.

---

## 🏗️ Architecture

UMECA Bulletin TV follows a modern, decoupled architecture:

```
┌─────────────────────────────────────────────────────────┐
│                     Browser (Client)                     │
│  ┌────────────────────────────────────────────────────┐ │
│  │         Next.js 15 + React 19 Frontend            │ │
│  │    (Auto-scrolling Carousel + Real-time Clock)    │ │
│  └───────────────────┬────────────────────────────────┘ │
└────────────────────────┼────────────────────────────────┘
                         │ HTTP/REST
                         ▼
┌─────────────────────────────────────────────────────────┐
│               Next.js API Routes (Proxy)                │
│          /api/bulletin → C# API Bridge                  │
└───────────────────┬─────────────────────────────────────┘
                    │ HTTP
                    ▼
┌─────────────────────────────────────────────────────────┐
│              C# .NET API Server                         │
│         (BulletinApiServer.cs)                          │
└───────────────────┬─────────────────────────────────────┘
                    │ ADO.NET
                    ▼
┌─────────────────────────────────────────────────────────┐
│           SQL Server LocalDB                            │
│       (ConsultationDatabase)                            │
└─────────────────────────────────────────────────────────┘
```

---

## 📁 Project Structure

```
📦 UMECA-Bulletin-TV
├── 📂 src/
│   ├── 📂 app/                      # Next.js App Router
│   │   ├── 📂 _components/          # Page-specific components
│   │   │   ├── 📄 bulletin.tsx      # 🎪 Carousel implementation
│   │   │   ├── 📄 card.tsx          # 📊 Overview card
│   │   │   ├── 📄 timeclock.tsx     # ⏰ Real-time clock
│   │   │   └── 📄 currentDate.tsx   # 📅 Date display
│   │   ├── 📂 api/
│   │   │   └── 📂 bulletin/
│   │   │       └── 📄 route.ts      # 🔌 API proxy to C# backend
│   │   ├── 📄 layout.tsx            # 🎨 Root layout + header
│   │   ├── 📄 page.tsx              # 🏠 Home page
│   │   └── 📄 globals.css           # 💅 Global styles & themes
│   ├── 📂 components/
│   │   └── 📂 ui/                   # Reusable UI components
│   │       ├── 📄 button.tsx
│   │       ├── 📄 card.tsx
│   │       └── 📄 carousel.tsx
│   ├── 📂 lib/
│   │   ├── 📄 db.ts                 # 🗄️ Database config
│   │   ├── 📄 utils.ts              # 🛠️ Utility functions
│   │   └── 📄 constants.ts          # ⚙️ App constants
│   └── 📂 types/
│       └── 📄 index.ts              # 📝 TypeScript definitions
├── 📂 public/
│   ├── 🖼️ logo.png                  # UMECA branding
│   └── 🎨 *.svg                     # Icon assets
├── 📂 docs/
│   ├── 📄 ARCHITECTURE.md           # Deep dive into system design
│   └── 📄 SETUP.md                  # Detailed setup instructions
├── 🔧 BulletinApiServer.cs          # C# API server
├── 🔧 CSharp-API-Bridge.cs          # Database bridge layer
├── 📄 package.json                  # Node dependencies
├── 📄 tsconfig.json                 # TypeScript config
├── 📄 tailwind.config.ts            # Tailwind CSS config
└── 📄 next.config.ts                # Next.js configuration
```

---

## 🛠️ Tech Stack

### 🎨 Frontend Powerhouse

| Technology | Version | Purpose |
|-----------|---------|---------|
| **Next.js** | 15.4.5 | React framework with App Router & SSR |
| **React** | 19.1.0 | UI component library |
| **TypeScript** | 5.0 | Type-safe JavaScript |
| **Tailwind CSS** | 4.0 | Utility-first styling |
| **Embla Carousel** | 8.6.0 | Smooth carousel animations |
| **Radix UI** | Latest | Accessible component primitives |
| **Day.js** | 1.11.13 | Date/time manipulation |
| **Lucide React** | 0.534.0 | Beautiful SVG icons |

### ⚙️ Backend Foundation

| Technology | Purpose |
|-----------|---------|
| **C# .NET** | API server & business logic |
| **SQL Server LocalDB** | Relational database |
| **ADO.NET** | Database connectivity |
| **mssql** (Node) | SQL Server driver for Next.js |

---

## 🎨 Customization Guide

### 🌈 Changing the Gradient Background

Edit `src/app/globals.css` and `src/app/layout.tsx`:

```css
/* In globals.css */
--background: linear-gradient(115deg, #ff512f, #dd2476);
```

```tsx
/* In layout.tsx */
className="bg-[linear-gradient(115deg,_#your-color-1,_#your-color-2)]"
```

### ⚡ Adjusting Carousel Speed

Edit `src/app/_components/bulletin.tsx`:

```typescript
const autoplayPlugin = React.useRef(
  Autoplay({ 
    delay: 5000, // Change delay in milliseconds (default: 5 seconds)
    stopOnInteraction: false,
  })
);
```

### 🖼️ Logo Customization

Simply replace `public/logo.png` with your institution's logo (recommended size: 200x200px).

---

## 🎪 Key Components Deep Dive

### 🎪 Bulletin Carousel
The star of the show. Uses Embla Carousel with autoplay to create smooth, infinite scrolling.

**Features:**
- Vertical scrolling with customizable speed
- Auto-advance with 5-second intervals
- Smooth easing transitions
- Loop mode for continuous playback
- Glass-morphism card design

### 📊 Overview Card
A fixed card displaying all bulletin titles, providing context for what's coming.

### ⏰ Real-time Clock
Updates every second using React hooks, displaying time in an elegant format.

```typescript
// Clock updates every second
useEffect(() => {
  const interval = setInterval(() => {
    setTime(dayjs().format('HH:mm:ss'));
  }, 1000);
  return () => clearInterval(interval);
}, []);
```

---

## � API Reference

### GET `/api/bulletin`
Fetches all active bulletins from the database.

**Response:**
```json
[
  {
    "Id": 1,
    "Title": "Campus Event Announcement",
    "Content": "Join us for the annual tech summit...",
    "DatePublished": "2025-11-03T14:30:00",
    "Author": "Admin",
    "Status": 1
  }
]
```

### POST `/api/bulletin`
Creates a new bulletin entry (if implemented).

**Request Body:**
```json
{
  "Title": "New Announcement",
  "Content": "Important bulletin content...",
  "Author": "Admin",
  "Status": 1
}
```

---

## � Deployment Options

### 🟢 Vercel (Recommended)

The easiest way to deploy:

```bash
# Install Vercel CLI
npm install -g vercel

# Deploy
vercel
```

Or use the [Vercel Dashboard](https://vercel.com/new) to import from GitHub.

### 🔵 Custom Server

```bash
# Build for production
npm run build

# Start production server
npm start
```

**Important:** Ensure your C# API server is deployed and accessible.

---

## 🎯 Usage Scenarios

### 📺 For TV Displays
1. Open the application in full-screen mode (`F11`)
2. The carousel will auto-play indefinitely
3. Perfect for lobby displays, cafeterias, and common areas

### 🖥️ For Kiosks
1. Set browser to kiosk mode
2. Disable mouse cursor if needed
3. Enable auto-refresh for bulletins

### 📱 For Mobile Viewing
The responsive design works beautifully on tablets and phones too!

---

## 🐛 Troubleshooting

<details>
<summary><strong>Database Connection Issues</strong></summary>

- ✅ Verify SQL Server LocalDB is installed and running
- ✅ Check connection string in `src/lib/db.ts`
- ✅ Ensure database name matches: `ConsultationDatabase`
- ✅ Test connection with SQL Server Management Studio

</details>

<details>
<summary><strong>C# API Not Starting</strong></summary>

- ✅ Install .NET SDK from [Microsoft](https://dotnet.microsoft.com/download)
- ✅ Check if port 5000 is available
- ✅ Review `BulletinApiServer.cs` for errors
- ✅ Run with: `dotnet run BulletinApiServer.cs`

</details>

<details>
<summary><strong>Carousel Not Auto-Playing</strong></summary>

- ✅ Check browser console for JavaScript errors
- ✅ Verify Embla Carousel dependencies are installed
- ✅ Ensure bulletins are being fetched successfully
- ✅ Check that bulletins array is not empty

</details>

<details>
<summary><strong>Styling Issues</strong></summary>

- ✅ Clear browser cache
- ✅ Run `npm install` to ensure all dependencies are present
- ✅ Check that Tailwind CSS is properly configured
- ✅ Verify `postcss.config.mjs` is correct

</details>

---

## � Learning Resources

Expand your knowledge with these excellent resources:

- 📘 [Next.js Documentation](https://nextjs.org/docs) - Master Next.js App Router
- 📗 [React Documentation](https://react.dev) - Learn React 19 features
- 📙 [Tailwind CSS](https://tailwindcss.com/docs) - Explore utility-first CSS
- 📕 [TypeScript Handbook](https://www.typescriptlang.org/docs) - Type-safe programming
- 📓 [Embla Carousel](https://www.embla-carousel.com/get-started/) - Carousel API docs

---

## 🤝 Contributing

We welcome contributions! Here's how you can help:

1. 🍴 Fork the repository
2. 🔧 Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. 💾 Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. 📤 Push to the branch (`git push origin feature/AmazingFeature`)
5. 🎉 Open a Pull Request

---

## 👥 Team

This project was crafted with ❤️ as part of the **CpE 223/L Group Project**.

### 🎓 Course Information
- **Course:** CpE 223/L - Software Development
- **Institution:** University of Mindanao
- **Department:** Electrical and Computer Engineering

### 👨‍💻 Development Team
- **System Architecture** - Backend & Database Design
- **Frontend Development** - UI/UX Implementation
- **API Integration** - C# Bridge & Data Flow
- **Testing & QA** - Quality Assurance & Documentation

---

## 📝 License

This project is developed for **educational purposes** as part of the CpE 223/L course requirements at the University of Mindanao.

---

## 🌟 Acknowledgments

Special thanks to:

- 🏫 **UMECA** - For inspiring this digital transformation
- 👨‍🏫 **Our Instructors** - For guidance and invaluable feedback
- ⚛️ **Next.js Team** - For the amazing React framework
- 🎨 **Vercel** - For the incredible deployment platform
- 💡 **Open Source Community** - For the tools and libraries

---

## 📞 Support & Contact

Have questions or need help?

- 📧 Email: [Contact your instructor]
- 💬 GitHub Issues: [Report bugs or request features](https://github.com/Setimo123/SD_FinalProject/issues)
- 📖 Documentation: Check `/docs` folder for detailed guides

---

## 🗺️ Roadmap

Future enhancements we're considering:

- [ ] 🔐 Admin dashboard for bulletin management
- [ ] 📱 Progressive Web App (PWA) support
- [ ] 🌐 Multi-language support
- [ ] 📊 Analytics dashboard
- [ ] 🎨 Theme customization panel
- [ ] 🔔 Push notifications
- [ ] 📸 Image/video support in bulletins
- [ ] 🔄 Real-time sync with WebSockets

---

<div align="center">

### ⭐ Star this repository if you found it helpful!

### Made with 💻, ☕, and countless hours of dedication

**[⬆ Back to Top](#-umeca-bulletin-tv)**

---

© 2025 UMECA Bulletin TV - CpE 223/L Final Project

</div>
