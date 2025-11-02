/**
 * Home Page Component
 * 
 * Fetches and displays bulletins from the API in a carousel format.
 * Handles loading states and error conditions.
 * 
 * @page
 */

import CarouselOrientation from "./_components/bulletin";

/**
 * Bulletin data type from API
 */
type BulletinData = {
  Id: number;
  Title: string;
  Status: number;
  Content: string;
  DatePublished: string;
}[];

/**
 * Main page component - fetches and displays bulletin carousel
 */
export default async function Page() {
  try {
    // Get base URL from environment or default to localhost
    const baseUrl = process.env.NEXT_PUBLIC_BASE_URL || 'http://localhost:3000';
    
    // Fetch bulletins from API (no caching for real-time updates)
    const bulletin = await fetch(`${baseUrl}/api/bulletin`, {
      cache: 'no-store'
    });
    
    if (!bulletin.ok) {
      throw new Error('Failed to fetch bulletins');
    }
    
    const data = await bulletin.json() as BulletinData;
    
    // Debug logging for development
    console.log('📊 Fetched data:', data);
    console.log('📊 Data length:', data?.length);
    console.log('📊 First item:', data?.[0]);
    
    // Handle empty bulletin list
    if (!data || data.length <= 0) {
      return (
        <div className="text-white text-center mt-10 text-2xl drop-shadow-lg">
          No bulletins available
        </div>
      );
    } 
    
    return <CarouselOrientation bulletinData={data} />;
    
  } catch (error) {
    console.error('❌ Error fetching bulletins:', error);
    return (
      <div className="text-white text-center mt-10 text-2xl drop-shadow-lg">
        Error loading bulletins
      </div>
    );
  }
}
