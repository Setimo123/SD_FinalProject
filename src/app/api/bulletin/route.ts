/**
 * Bulletin API Route
 * 
 * Proxies requests to the C# API server that connects to SQL Server LocalDB.
 * This acts as a bridge between the Next.js frontend and the C# backend.
 * 
 * Endpoints:
 * - GET: Fetch all bulletins
 * - POST: Create a new bulletin
 * 
 * @api
 */

import { NextRequest, NextResponse } from 'next/server';

// C# API server URL (configured via environment variable)
const CS_API_URL = process.env.CS_API_URL || 'http://localhost:5000/api/bulletin';

/**
 * GET handler - Fetches all bulletins from the C# API
 * 
 * @returns JSON array of bulletins
 * @throws 500 error if C# API is unreachable or returns an error
 */
export async function GET() {
  try {
    console.log('🔄 Fetching bulletins from C# API:', CS_API_URL);
    
    // Fetch from C# API with no caching for real-time data
    const response = await fetch(CS_API_URL, {
      cache: 'no-store',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    if (!response.ok) {
      throw new Error(`C# API responded with status: ${response.status}`);
    }

    const data = await response.json();
    
    // Transform data to ensure consistent PascalCase format
    const transformedData = data.map((item: any) => ({
      Id: item.id || item.Id,
      Title: item.title || item.Title,
      Author: item.author || item.Author,
      Content: item.content || item.Content,
      Status: item.status || item.Status,
      DatePublished: item.datePublished || item.DatePublished,
      FileCount: item.fileCount || item.FileCount,
      IsArchived: item.isArchived || item.IsArchived,
    }));
    
    console.log('✅ Successfully fetched', transformedData.length, 'bulletins from C# API');
    
    return NextResponse.json(transformedData);
  } catch (error: any) {
    console.error('❌ Error fetching from C# API:', error?.message);
    return NextResponse.json(
      { error: 'Failed to fetch bulletins from C# API', details: error?.message },
      { status: 500 }
    );
  }
}

/**
 * POST handler - Creates a new bulletin via the C# API
 * 
 * @param req - Next.js request object containing bulletin data
 * @returns JSON response with created bulletin data
 * @throws 500 error if C# API is unreachable or returns an error
 */
export async function POST(req: NextRequest) {
  try {
    const body = await req.json();
    
    console.log('🔄 Posting bulletin to C# API:', CS_API_URL);

    // Forward request to C# API
    const response = await fetch(CS_API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(body),
    });

    if (!response.ok) {
      throw new Error(`C# API responded with status: ${response.status}`);
    }

    const data = await response.json();
    console.log('✅ Successfully posted bulletin to C# API');
    
    return NextResponse.json(data);
  } catch (error: any) {
    console.error('❌ Error posting to C# API:', error?.message);
    return NextResponse.json(
      { error: 'Failed to post bulletin to C# API', details: error.message },
      { status: 500 }
    );
  }
}
